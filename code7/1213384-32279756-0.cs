    private bool NodeExists(TreeNode node, string key) 
    {
        foreach (TreeNode subNode in node.Nodes) 
        {
            if ( subNode.Text.Equals(key) ) 
            {
                return true;
            }
            var nodeChildExists = NodeExists( subNode.Nodes, key );
            if(nodeChildExists)
            {
                return true;
            }
        }
        return false;
    }
