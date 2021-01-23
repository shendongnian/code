    private void button_Click(object sender, EventArgs e)
    {
        var dirs = Directory.GetDirectories ("D:\\").ToArray();
        var nodes = new List<TreeNode>();
        foreach(string dir in dirs)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            TreeNode tn = new TreeNode(di.Name);
            tn.Tag = di;
            tn.Nodes.Add("...");
            nodes.Add(tn);
        }
        treeView1.Nodes.AddRange(nodes.ToArray());
    }
    private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        TreeNode tn = e.Node.Nodes[0];
        if (tn.Text == "...")
        {
            loadNode(tn, ((DirectoryInfo)e.Node.Tag).FullName );
        }
    }
    void  loadNode(TreeNode node, string dir )
    {
        var dirs = Directory.GetDirectories(dir).ToArray();
        var nodes = new List<TreeNode>();
        foreach (string d in dirs)
        {
            DirectoryInfo di = new DirectoryInfo(d);
            TreeNode tn = new TreeNode(di.Name);
            tn.Tag = di;
            tn.Nodes.Add("...");
            nodes.Add(tn);
        }
        node.Parent.Nodes.AddRange(nodes.ToArray());
        node.Parent.Nodes.Remove(node);
    }
