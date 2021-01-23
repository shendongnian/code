    public void makeTree()
    {
    	//Make a Dictionary with the ID als key
    	Dictionary<int, Category> categories = this.Query().Select().ToDictionary(a => a.ID, a => a);
    	
    	foreach (Category c in categories)
    	{
    		if (c.ParentID != 0)
    		{
    			if (categories[c.ParentID].children == null)
    			{
    				categories[c.ParentID].children = new List<Category>();
    			}
    			categories[c.ParentID].children.add(c);			
    		}//ParentID == 0 means its a root element
    	}
    }
