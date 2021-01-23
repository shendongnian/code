    void AddNodes(TreeView tv, TreeNode cNode, List<Tuple<int, string>> nList)
    {
        TreeNode nNode = new TreeNode();
        int nLevel = cNode.Level;
        Tuple<int, string> t = nList[0];
        // sibling: add to our parent!
        if (t.Item1 == nLevel) { nNode = cNode.Parent.Nodes.Add(t.Item2); }
        // next generation: our own child!
        else if (t.Item1 == nLevel + 1) { nNode = cNode.Nodes.Add(t.Item2); }
        // below us: seek down the line of parents!
        else if (t.Item1 < nLevel) {
            while (t.Item1 < cNode.Level) cNode = cNode.Parent;
            nNode = cNode.Parent.Nodes.Add(t.Item2); }
        // more than 1 above: error!
        else { Console.WriteLine("Error: node levels must not jump up: " + 
                                  nLevel + " --> " + t.Item1); }
        // done with this element
        nList.RemoveAt(0);
        // anything left to do?
        if (nList.Count > 0) AddNodes(treeView1, nNode, nList);
    }
