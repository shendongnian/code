    public class Navigation
    {
        public static List<NavMenuItem> GetNavigationMenuItems()
        {
            var list = new List<NavMenuItem>(
            new[]
            {
                new NavMenuItem()
                {
                    Symbol = Symbol.Contact,
                    Label = "Personal",
                    DestPage = typeof(PersonalView)
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.World,
                    Label = "Countries",
                    DestPage = typeof(CountriesView)
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.Setting,
                    Label = "Settings",
                    DestPage = typeof(SettingsView)
                },
            });
            return list;
        }
    }
