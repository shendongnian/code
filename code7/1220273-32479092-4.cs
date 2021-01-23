    public static void CheckParentsAndChildren(this TreeNode node)
    {
        node.CheckChildren(); // Check children of current node only.
        TreeNode parent = node.Parent;
        while (parent != null) // ; <-- this semicolon was the problem!!
        {
            parent.Checked = true;
            parent = parent.Parent;
        }
    }
