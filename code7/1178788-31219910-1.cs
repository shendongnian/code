    namespace textfile
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void LoadButton(object sender, RoutedEventArgs e)
            {
                foreach (string line in File.ReadAllLines(@"GLG_001.TXT"))
                {
                    var listViewItem = new ListViewItem();
                    listViewItem.Content = line;
    
                    ListView.Items.Add(listViewItem);
                }
            }
        }
    }
