    class ParentClass
    {
        private Dictionary<ReturnMenuType, List<IMenu>> _menuItems = InitMenuItems();
        private static Dictionary<ReturnMenuType, List<IMenu>> InitMenuItems()
        {
            return new Dictionary<ReturnMenuType, List<IMenu>>()
            {
                { ReturnMenuType.TopLevel, new List<IMenu>() { some items } },
                { ReturnMenuType.MidLevel, new List<IMenu>() { some items } },
                { ReturnMenuType.BottomLevel, new List<IMenu>() { some items } }
            };
        }
        // getting menu for a level is now as simple as querying the dictionary
        public IEnumerable<IMenu> GetMenusForLevel(ReturnMenuType type)
        {
            return _menuItems[type];
        }
    }
