      [Dependency]
      public Foo Foo { get; set; }
    
      public MainWindow()
            {
                InitializeComponent();
    
                Loaded += MainWindow_Loaded;
            }
    
      private void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
            {
                // Propery injection should have taken place now, so do what you need to do with them
            }
