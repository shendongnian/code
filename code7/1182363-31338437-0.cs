    public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            var list = new List<Item>
            {
                new Item { Name = "Item 1" },
                new Item { Name = "Item 2" },
                new Item { Name = "Item 3" },
                new Item { Name = "Item 4" },
                new Item { Name = "Item 5" },
                new Item { Name = "Item 6" },
                new Item { Name = "Item 7" },
                new Item { Name = "Item 8" }
            };
            this.AppBarMenu.ItemsSource = list;
        }
