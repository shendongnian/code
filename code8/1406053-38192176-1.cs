    public void checkChildren(TreeNode original, string path, string node)
    {
        foreach (TreeNode tnode in original.Nodes)
        {
            if (tnode.FullPath == path)
            {
                tnode.Nodes.Add(node);
                break;
            }
    
            checkChildren(tnode, path, node);
        }
    }
