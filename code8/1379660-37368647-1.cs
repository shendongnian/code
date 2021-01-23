    IEnumerable<Entity.MenuItem> _menuItemList = _menuItemRepository.FindByIncluding(x => x.Parent == null && x.onMenu == true, t => t.Children);
    IEnumerable<Entity.MenuItem> _allItems = GetAllMenuItems(_menuItemList);
    public IEnumerable<MenuItem> GetAllMenuItems(IEnumerable<MenuItem> rootMenuItems)
    {
        IEnumerable<MenuItem> result = rootMenuItems;
        foreach (MenuItem menuItem in rootMenuItems)
        {
            result = result.Concat(menuItem.GetDescendants(false))
        }
        return result;
    }
