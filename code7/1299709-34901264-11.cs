    public static class TreeViewUtils
    {
    	public static TreeNode FindNode(TreeNodeCollection nodes, int index)
    	{
    		int offset = -1;
    		return FindNode(nodes, ref offset, index);
    	}
    	private static TreeNode FindNode(TreeNodeCollection nodes, ref int offset, int index)
    	{
    		for (int i = 0; i < nodes.Count; i++)
    		{
    			var node = nodes[i];
    			if (++offset == index || (node = FindNode(node.Nodes, ref offset, index)) != null)
    				return node;
    		}
    		return null;
    	}
    }
