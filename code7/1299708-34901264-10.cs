    public static class TreeViewUtils
    {
    	public static IEnumerable<TreeNode> AsEnumerable(this TreeNodeCollection source)
    	{
    		return source.Cast<TreeNode>();
    	}
    
    	public static IEnumerable<TreeNode> All(this TreeNodeCollection source)
    	{
    		return source.AsEnumerable().Expand(node => node.Nodes.Count > 0 ? node.Nodes.AsEnumerable() : null);
    	}
    
    	public static TreeNode Find(this TreeNodeCollection source, int index)
    	{
    		return source.All().Skip(index).FirstOrDefault();
    	}
    }
