    using System;
    using System.Windows.Forms;
    namespace TreeViewExample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void btnNew_Click(object sender, EventArgs e)
            {
                var nodeDialog = new NodeNameDialog();
                var result = nodeDialog.ShowDialog();
                if (result == DialogResult.OK)
                    treeView1.Nodes.Add(nodeDialog.NodeName);
            }
        }
    }
