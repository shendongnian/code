    public HtmlNodeCollection SelectNodes(string xpath)
    {
    	HtmlNodeCollection list = new HtmlNodeCollection(null);
    
    	HtmlNodeNavigator nav = new HtmlNodeNavigator(_ownerdocument, this);
    	XPathNodeIterator it = nav.Select(xpath);
    	while (it.MoveNext())
    	{
    		HtmlNodeNavigator n = (HtmlNodeNavigator) it.Current;
    		list.Add(n.CurrentNode);
    	}
    	if (list.Count == 0)
    	{
    		return null;
    	}
    	return list;
    }
