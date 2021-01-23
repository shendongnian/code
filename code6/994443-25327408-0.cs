    var hierarchical = menuItems.Where(m => m.ParentID == null)
    								.GroupJoin(menuItems,
    											m => m.MenuItemID, 
    											m => m.ParentID,
    											(parentMenuItems, childMenuItems) => new
    											{
    												ParentMenuItems = parentMenuItems,
    												ChildMenuItems = childMenuItems.GroupJoin(menuItems,
    												m => m.MenuItemID, 
    												m => m.ParentID,
    												(subParentMenuItems, subChildMenuItems) => new
    												{
    													ParentMenuItems = subParentMenuItems,
    													ChildMenuItems = subChildMenuItems
    												})
    											});
    											
    	foreach(var menu in hierarchical)
    	{
    		Console.WriteLine(menu.ParentMenuItems.MenuItemName);
    		foreach(var submenu in menu.ChildMenuItems)
    		{
    			Console.WriteLine("\t" + submenu.ParentMenuItems.MenuItemName);
    			foreach(var subitem in submenu.ChildMenuItems)
    			{
    				Console.WriteLine("\t\t" + subitem.MenuItemName);
    			}
    		}
    	}
