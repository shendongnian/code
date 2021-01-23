    It doesn't look like you need to use the overload that takes two parameters, so you could tweak the method:
        var result = Mapper.Map<List<MenuItemQueryResult>(menuItems);
    And then in your test:
        Mapper.Setup(m => m.Map<List<MenuItem>, List<MenuItemQueryResult>>(It.IsAny<List<MenuItem>>())
        Mapper
            .Setup(m => m.Map<List<MenuItem>, List<MenuItemQueryResult>>(It.IsAny<List<MenuItem>>()))
            .Returns(menuItemQueryResult);
