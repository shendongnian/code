    class ParentClass
    {
        private Dictionary<ReturnMenuType, List<IMenu>> _menuItems = InitMenuItems();
        // getting menu for a level is now as simple as querying the dictionary
        public IEnumerable<IMenu> GetMenusForLevel(ReturnMenuType type)
        {
            return _menuItems[type];
        }
    }
