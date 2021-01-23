    private ObservableCollection<item> loadedCategory = new ObservableCollection<item>();
    public MainWindow()
    {
        InitializeComponent();
        left_panel_lower_list.ItemsSource = loadedCategory;
    }
    private void Open_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            foreach(var item in loaders.category_loader(openFileDialog.FileName)
            {
                loadedCategory.Add(item);
            }
        }        
    }
