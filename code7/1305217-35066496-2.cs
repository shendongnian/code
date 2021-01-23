    private string ExtractContentFromHtml(string input)
    {
    	List<string> tagsToRemove = new List<string>
    	{
    		"script",
    		"style",
    		"img"
    	};
    
    	var config = Configuration.Default.WithJavaScript();
    
    	HtmlParser hp = new HtmlParser(config);
    	List<IElement> tags = new List<IElement>();
    	List<string> nodeTypes = new List<string>();
    	var hpResult = hp.Parse(input);
    
    	List<string> textNodesValues = new List<string>();
    	try
    	{
    		foreach (var tagToRemove in tagsToRemove)
    			tags.AddRange(hpResult.QuerySelectorAll(tagToRemove));
    
    		foreach (var tag in tags)
    			tag.Remove();
    
    
     
    /*
       the following will not work, because text nodes that are not immediate children will not be considered 
       textNodesValues = hpResult.All.Where(n => n.NodeType == NodeType.Text).Select(n => n.TextContent).ToList();
    */
    
    
    		var treeWalker = hpResult.CreateTreeWalker(hpResult, FilterSettings.Text);
    
    		var textNode = treeWalker.ToNext();
    		while (textNode != null)
    		{
    			textNodesValues.Add(textNode.TextContent);
    			textNode = treeWalker.ToNext();
    		}
    	}
    	catch (Exception ex)
    	{
    		_errors.Add(string.Format("Error in cleaning html. {0}", ex.Message));
    	}
    
    	return string.Join(" ", textNodesValues);
    }
