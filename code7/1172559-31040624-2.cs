    This is a little less intuitive, but possible. You'll have to provide a fake implementation of the `Map` method:    
        Mapper
            .Setup(m => m.Map<List<MenuItem>, List<MenuItemQueryResult>>(It.IsAny<List<MenuItem>>(), It.IsAny<List<MenuItem>>()))
            .Callback((List<MenuItem> menuItems, List<MenuItemQueryResult> queryResults) =>
            {
                queryResults.AddRange(menuItemQueryResult);
            });
