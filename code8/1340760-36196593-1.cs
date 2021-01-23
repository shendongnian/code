    public partial class Form1
    {
        private TreeView treeView1;
        private TextBox textBox1;
        // ... shortened example
        public Form1()
        {
            InitializeComponent();
            treeView1.AfterSelect += treeView1_AfterSelect;
            //...
        }
 
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string description = string.Empty;
            TreeNode node = treeView1.SelectedNode;
            if (node != null)
                description = // determine the text from your country data
            textBox1.Text = description;
        }
    }
