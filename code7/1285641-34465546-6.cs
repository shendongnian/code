    // somewhere:
    string yourRoot = "D:\\";
    treeView1.Nodes.AddRange(getFolderNodes(yourRoot, true).ToArray());
    private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        TreeNode tn = e.Node.Nodes[0];
        if (tn.Text == "...")
        {
            e.Node.Nodes.AddRange(getFolderNodes(((DirectoryInfo)e.Node.Tag)
                  .FullName, true).ToArray());
            if (tn.Text == "...") tn.Parent.Nodes.Remove(tn);
        }
    }
    List<TreeNode> getFolderNodes(string dir, bool expanded)
    {
        var dirs = Directory.GetDirectories(dir).ToArray();
        var nodes = new List<TreeNode>();
        foreach (string d in dirs)
        {
            DirectoryInfo di = new DirectoryInfo(d);
            TreeNode tn = new TreeNode(di.Name);
            tn.Tag = di;
            int subCount = 0;
            try { subCount = Directory.GetDirectories(d).Count();  } 
            catch { /* ignore accessdenied */  }
            if (subCount > 0) tn.Nodes.Add("...");
            if (expanded) tn.Expand();   //  **
            nodes.Add(tn);
        }
        return nodes;
    }
