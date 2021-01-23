    void copyImgIndexToChildren(TreeNode tn)
    {
        if (tn.Nodes.Count > 0) 
            foreach (TreeNode cn in tn.Nodes) cn.ImageIndex = tn.ImageIndex;
    }
    void copyImgIndexToAllChildren(TreeNode tn)
    {
        if (tn.Nodes.Count > 0)
            foreach (TreeNode cn in tn.Nodes)
            {
                cn.ImageIndex = tn.ImageIndex;
                copyImgIndexToAllChildren(cn);
            }
    }
