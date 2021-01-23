    public MenuRepository(IMonopolyEntitiesDbContext context, IList<MenuLink> allsubMenus)
    {
        _dbContext = context;
        _allsubMenus = allsubMenus;
    }
