    var menuLinks = new List<MenuLink>
    {
        new MenuLink { Id = 1, Name = "foo" },
        new MenuLink { Id = 2, Name = "bar" },
        new MenuLink { Id = 3, Name = "foobar" },
    };
    container.RegisterType<IMenuRepository, MenuRepository>(
        new PerThreadLifetimeManager(), 
        new ParameterOverride("allsubMenus", menuLinks));
