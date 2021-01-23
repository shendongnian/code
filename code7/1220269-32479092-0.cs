    public static void CheckParentsAndChildren(this TreeNode node)
    {
        node.CheckChildren();
        TreeNode parent = node.Parent;
        while (parent != null) ;
        {
            parent.Checked = true;
            parent = parent.Parent;
        }
    }
