    public bool AnyChildren() { return l != null || r != null; }
    public IEnumerable<TreeNode> Children
    {
    	get
    	{
    		if (l != null) yield return l;
    		if (r != null) yield return r;
    	}
    }
    public IEnumerable<TreeNode> Traverse(bool preOrder = false)
    {
    	return TreeHelper.Traverse(this, node => node.AnyChildren() ? node.Children : null, preOrder);
    }
