        public MainWindow()
        {
            InitializeComponent();
            ButtonToggle.Click += ButtonToggleOnClick;
        }
        private void ButtonToggleOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            toBeCollapsed.Visibility = toBeCollapsed.Visibility == Visibility.Collapsed
                ? Visibility.Visible
                : Visibility.Collapsed;
        }
