    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoadButton(object sender, RoutedEventArgs e)
        {
            foreach (string line in File.ReadAllLines(@"GLG_001.TXT"))
                ListView.Items.Add(new ListViewItem(line));
        }
      
        }
       
    }
