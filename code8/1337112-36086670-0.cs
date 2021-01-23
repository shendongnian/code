    	var ordered = unorderedModel.OrderBy(x=>x.SortOrder).ToList();
    	ordered.ForEach(OrderChildren);
    
    public void OrderChildren(NavigationElement el)
    {
    	el.Children = el.Children.OrderBy(x => x.Title).ToList();
    	if (el.Children != null)
    	{
    		foreach (var c in el.Children)
    		{
    			OrderChildren(c);
    		}
    	}
    }
