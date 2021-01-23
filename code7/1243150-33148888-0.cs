    private void TreeViewAddNode(TreeView treeView, string path, char pathSeparator)
    {
        string[] split = path.Split(pathSeparator);
    
        foreach(string s in split)
        {
            treeView.Nodes.Add(s);
        }
    }
