    List<TreeNode> getAllFolderNodes(string dir)
    {
        var dirs = Directory.GetDirectories(dir).ToArray();
        var nodes = new List<TreeNode>();
        foreach (string d in dirs)
        {
            DirectoryInfo di = new DirectoryInfo(d);
            TreeNode tn = new TreeNode(di.Name);
            tn.Tag = di;
            int subCount = 0;
            try { subCount = Directory.GetDirectories(d).Count(); } 
            catch { /* ignore accessdenied */  }
            if (subCount > 0)
            {
                var subNodes = getAllFolderNodes(di.FullName);
                tn.Nodes.AddRange(subNodes.ToArray());
            }
            nodes.Add(tn);
        }
        return nodes;
    }
