    private void Form1_Load(object sender, EventArgs e)
    {
       PopulateTree(@"C:\treeview", treeView1.Nodes.Add("I want to remove this node"));
    }
    public void PopulateTree(string dir, TreeNode node)
    {
        DirectoryInfo directory = new DirectoryInfo(dir);
        foreach (DirectoryInfo d in directory.GetDirectories())
        {
            TreeNode t = new TreeNode(d.Name);
            PopulateTree(d.FullName, t);
            node.Nodes.Add(t);
        }
        foreach (FileInfo f in directory.GetFiles())
        {
            TreeNode t = new TreeNode(f.Name);
            node.Nodes.Add(t);
        }
    }
