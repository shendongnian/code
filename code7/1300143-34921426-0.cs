    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                ChangeTree(treeView1);
            }
    
            public void ChangeTree(TreeView tree)
            {
                Thread thread4 = new Thread(() => { UpdateTreeView(tree); });
                thread4.Name = "Thread 4";
                thread4.IsBackground = true;
                thread4.Start();
            }
    
            private void UpdateTreeView(TreeView tree)
            {
                if (tree.InvokeRequired)
                {
                    tree.Invoke((MethodInvoker)delegate
                    {
                        UpdateTreeView(tree);
                    });
                }
                else
                {
                    tree.Nodes.Clear();
                    foreach (var node in GetTree())
                    {
                        tree.Nodes.Add(node as TreeNode);
                    }
                }
            }
    
            private List<TreeNode> GetTree()
            {
                var result = new List<TreeNode>();
    
                result.Add(new TreeNode("changed"));
    
                return result;
            }
        }
    }
