        ObservableCollection<DynamicTableColumn> Collection = new ObservableCollection<DynamicTableColumn>();
        public MainWindow()
        {
            InitializeComponent();
            icDynamicTableColumn.ItemsSource = Collection;
            Loaded += MainWindow_Loaded;
        }
        private StackPanel Panel;
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //find the panel that contains the children
            Panel = (StackPanel)VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(
                     VisualTreeHelper.GetChild(icDynamicTableColumn, 0), 0), 0);
        }
        TextBox GetTextBoxForIndex(int index)
        {
            //get the child for a given index
            var presenter = (ContentPresenter)VisualTreeHelper.GetChild(Panel, index);
            return (TextBox)presenter.ContentTemplate.FindName("lblName", presenter);
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Collection.Add(new DynamicTableColumn());
            //make sure that the Textbox was loaded
            icDynamicTableColumn.UpdateLayout();
            var textBox = GetTextBoxForIndex(Collection.Count - 1);
        }
