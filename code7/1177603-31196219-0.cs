    sealed partial class App : Application
    {
        public App()
        {
            WindowsAppInitializer.InitializeAsync("XXXXXX-XXXXXX");
            InitializeComponent();        
        }
    }
