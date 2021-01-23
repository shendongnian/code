        public MainPage()
        {
            this.InitializeComponent();
            IWantToAccessThis.ItemTemplate = Resources["TestTemplate"] as DataTemplate;
        }
