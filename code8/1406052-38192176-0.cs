    public void AddParent(string path, string node)
    {
        foreach (TreeNode tnode in treeView1.Nodes)
        {
            if (tnode.FullPath == path)
            {
                tnode.Nodes.Add(node);
                break;
            }
    
            checkChildren(tnode, path, node);
        }
    
        treeView1.ExpandAll();
    }
