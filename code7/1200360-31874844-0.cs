    public IEnumerable<Item> GetItems(IEnumerable<Item> items)
    {
	    foreach(var item in items)
    	{
	    	yield return item;
		    foreach(var child in GetItems(item.Children))
    		{
	    		yield return child;
		    }
	     }
     }
