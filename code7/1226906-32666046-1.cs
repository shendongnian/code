    /// <summary>
    /// Get all descendant nodes with matching name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public IEnumerable<HtmlNode> Descendants(string name)
    {
    	foreach (HtmlNode node in Descendants())
    		if (node.Name == name)
    			yield return node;
    }
