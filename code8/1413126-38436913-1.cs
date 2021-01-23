      public MainWindow()
        {
            InitializeComponent();
            for(int i=0;i<=10;i++)
            rgcCategory.Items.Add(i);
        }
      private void RibbonGallery_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            MessageBox.Show(rcmbCategory.SelectionBoxItem.ToString());
        }
