    public BlankPage()
            {
                this.InitializeComponent();
                this.Loaded += Page_Loaded;
            }
    
            private void Page_Loaded(object sender, RoutedEventArgs e)
            {
                var s = ApplicationView.GetForCurrentView();
                s.TryResizeView(new Size { Width = 600, Height = 320 });
            }
