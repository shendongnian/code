    private void ConstructLinks()
    {
    	if (MenuLinkGroups.Any())
    	{
    		MenuLinkGroups.Clear();
    		TitleLinks.Clear();
    	}
    
    	var group = new LinkGroup {DisplayName = "Home"};
    	var link = new Link { DisplayName = "Home", Source = MenuLinks.Home };
    
    	group.Links.Add(link);
    	MenuLinkGroups.Add(group);
    	group = new LinkGroup{DisplayName = "Menu 1"};
    	link = new Link {DisplayName = "Menu Item 1", Source = MenuLinks.Item1};
    	group.Links.Add(link);
    	link = new Link {DisplayName = "Menu Item 2", Source = MenuLinks.Item2};
    	group.Links.Add(link);
    	MenuLinkGroups.Add(group);
    
    
    	group = new LinkGroup { DisplayName = "Menu 2" };
    
    	link = new Link { DisplayName = "Menu Item3", Source = MenuLinks.Item3 };
    	group.Links.Add(link);
    	link = new Link {DisplayName = "Menu Item 4", Source = MenuLinks.Item4};
    	group.Links.Add(link);
    	MenuLinkGroups.Add(group);
    	
    	// Settings
    	link = new Link { DisplayName = "Settings", Source = MenuLinks.Settings };
    	TitleLinks.Add(link);
    }
