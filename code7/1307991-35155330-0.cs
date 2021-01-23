    void ColorNode(TreeNodeCollection nodes)
    {
    
        foreach (var child in nodes)
        {
            child.ForeColor= Color.Green;
            if(child.Nodes != null && child.Nodes.Count>0)
              ColorNode(child.Nodes);
        }
    }
