    void ColorNode(TreeNodeCollection nodes, System.Drawing.Color Color)
    {
    
        foreach (TreeNode child in nodes)
        {
            child.ForeColor= Color;
            if(child.Nodes != null && child.Nodes.Count>0)
              ColorNode(child.Nodes, Color);
        }
    }
