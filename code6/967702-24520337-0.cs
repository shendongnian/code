        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("DataKey"))
            {
                settings.Add("DataKey", "First Time");
            }
            else
            {
                settings["DataKey"] = "Not First Time";
                this.NavigationService.Navigate(new Uri("/Dashboard.xaml", UriKind.Relative));
            }
            settings.Save();
        }
