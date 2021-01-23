    public class MenuProvider
    {
        private readonly IMenuFilter _menuFilter;
        public MenuProvider(IMenuFilter menuFilter)
        {
            _menuFilter = menuFilter;
        }
        public Menu GetMenu(string menuId)
        {
            //code that gets the menu
            //filter the menu
            _menuFilter.FilterMenu(menu);
            return menu;
        }
    }
