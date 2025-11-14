using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innovatec.Vista
{
    public partial class Arbol : Form
    {
        public Arbol()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (tvArbol.SelectedNode != null)
            {
                tvArbol.SelectedNode.Nodes.Add(tbRama.Text);
            }
            if (tvArbol.Nodes.Count == 0)
            {
                tvArbol.Nodes.Add(tbRama.Text);
            }
            tvArbol.ExpandAll();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = tbRama.Text.Trim();

            TreeNode nodo = BuscarNodo(tvArbol.Nodes, texto);
            if (nodo != null)
            {
                tvArbol.SelectedNode = nodo;
                nodo.EnsureVisible();
                tvArbol.Focus();
            }
            else
            {
                MessageBox.Show("Nodo no encontrado: " + texto);
            }

        }
        private TreeNode BuscarNodo(TreeNodeCollection nodes, string texto)
        {
            foreach (TreeNode node in nodes)
            {
                if (string.Equals(node.Text, texto, StringComparison.OrdinalIgnoreCase))
                    return node;

                TreeNode encontrado = BuscarNodo(node.Nodes, texto);
                if (encontrado != null)
                    return encontrado;
            }
            return null;
        }

        private void btnConteo_Click(object sender, EventArgs e)
        {
            // contar los nodos que tiene cada rama

            if (tvArbol.SelectedNode != null)
            {
                int conteo = 0;

                ContarNodos(tvArbol.SelectedNode, ref conteo);

                MessageBox.Show("La rama " + tvArbol.SelectedNode.Text + " tiene " + conteo + " nodos.");
            }
            else
            {
                MessageBox.Show("Seleccione una rama para contar sus nodos.");
            }
        }

        private void ContarNodos(TreeNode nodo, ref int contador)
        {
            contador++;
            foreach (TreeNode hijo in nodo.Nodes)
            {
                ContarNodos(hijo, ref contador);
                
            }
            contador = -1;
        }
    }
}
