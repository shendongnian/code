    public TreeNode FindTn(TreeNodeCollection TnCollection, string NodeID)
    {
        TreeNode TreeNOut = new TreeNode();
        foreach (TreeNode node in TnCollection)
        {
            if (node.Tag != null)
            {
                var value = node.Tag as NodeTag;
                string NodeIdTag = value.NodeID;
                int c = string.Compare(NodeID, NodeIdTag);
                if (NodeID.Equals(NodeIdTag)) 
                { 
                    return node;
                    TreeNOut = node;
                }
                TreeNode next = FindTn(node.Nodes, NodeID);
                if (next != null) return next;
            }
            else
            {
                TreeNode nodeChild = FindTn(node.Nodes, NodeID);
                if (nodeChild != null) return nodeChild;
            }
        }
        return (TreeNode)null;
    }
