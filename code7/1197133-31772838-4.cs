    void AddNodes(TreeView tv, TreeNode cNode, List<Tuple<int, string>> nList)
    {
        TreeNode nNode = new TreeNode();
        int nLevel = cNode.Level;
        Tuple<int, string> t = nList[0];
        if (t.Item1 == nLevel) { nNode = cNode.Parent.Nodes.Add(t.Item2); }
        else if (t.Item1 == nLevel + 1) { nNode = cNode.Nodes.Add(t.Item2); }
        else if (t.Item1 < nLevel) {
            while (t.Item1 < cNode.Level) cNode = cNode.Parent;
            nNode = cNode.Parent.Nodes.Add(t.Item2); }
        else { Console.WriteLine("Error: node levels must not jump up: " + 
                                  nLevel + " --> " + t.Item1); }
        nList.RemoveAt(0);
        if (nList.Count > 0) AddNodes(treeView1, nNode, nList);
    }
