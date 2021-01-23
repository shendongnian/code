    /*
    	since the reason behind me wishing to remove comment, nodes, 
    	script, img and style nodes is that I am interested in text nodes only, 
    	the following might replace the whole block of code above 
    */
    
    List<string> textNodesValues = new List<string>();
    
    /*
       the following will not work, because text nodes that are not immediate children will not be considered 
       textNodesValues = hpResult.All.Where(n => n.NodeType == NodeType.Text).Select(n => n.TextContent).ToList();
    */
    
    //I then figured out this way, and it works:
    var treeWalker = hpResult.CreateTreeWalker(hpResult, FilterSettings.Text);
    
    var textNode = treeWalker.ToNext();
    while (textNode != null)
    {
    	textNodesValues.Add(textNode.TextContent);
    	textNode = treeWalker.ToNext();
    }
