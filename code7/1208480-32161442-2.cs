            var menuItems = new MenuItemCollection();
            menuItems.Add(new MenuItem() { SiteMenuId = 1, ParentId = null, MenuName = "Menu", Url = null, SiteId = 1 });
            menuItems.Add(new MenuItem() { SiteMenuId = 2, ParentId = 1, MenuName = "aaa", Url = "aaa", SiteId = 1 });
            menuItems.Add(new MenuItem() { SiteMenuId = 3, ParentId = 1, MenuName = "bbb", Url = null, SiteId = 1 });
            menuItems.Add(new MenuItem() { SiteMenuId = 4, ParentId = 3, MenuName = "ccc", Url = "ccc", SiteId = 1 });
            menuItems.Add(new MenuItem() { SiteMenuId = 5, ParentId = 3, MenuName = "ddd", Url = "ddd", SiteId = 1 });
            menuItems.Add(new MenuItem() { SiteMenuId = 6, ParentId = 1, MenuName = "eee", Url = "eee", SiteId = 1 });
            var json = JsonConvert.SerializeObject(menuItems,Formatting.Indented);
