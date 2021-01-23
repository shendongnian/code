      public MainPage()
      {
         this.InitializeComponent();
         // Set theme for window root
         FrameworkElement root = (FrameworkElement)Window.Current.Content;
         root.RequestedTheme = AppSettings.Theme;
         SetThemeToggle(AppSettings.Theme);
      }
