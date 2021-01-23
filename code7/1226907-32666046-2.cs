    /// <summary>
    /// Gets all Descendant nodes for this node and each of child nodes
    /// </summary>
    /// <returns></returns>
    public IEnumerable<HtmlNode> DescendantNodes()
    {
    	foreach (HtmlNode node in ChildNodes)
    	{
    		yield return node;
    		foreach (HtmlNode descendant in node.DescendantNodes())
    			yield return descendant;
    	}
    }
   
    
    /// <summary>
    /// Gets all Descendant nodes in enumerated list
    /// </summary>
    /// <returns></returns>
    public IEnumerable<HtmlNode> Descendants()
    {
    	foreach (HtmlNode node in DescendantNodes())
    	{
    		yield return node;
    	}
    }
   
