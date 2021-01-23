    public IEnumerable<IMenu> GetVisibleMenusForLevel(ReturnMenuType returnType)
    {
        if (returnType == ReturnMenuType.TopLevel)
            return GetVisibleMenus(db.TopLevelMenu);
        if (returnType == ReturnMenuType.MidLevel)
            return GetVisibleMenus(db.MidLevelMenu);
       
        // otherwise return the bottom menu
        return GetVisibleMenus(db.BottomLevelMenu);
    }
