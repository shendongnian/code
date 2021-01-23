    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpContextMenu();
            SetUpComboBox();
        }
        private void SetUpComboBox()
        {
            cb1.Items.Add("Sql1");
            cb1.Items.Add("Sql2");
            cb1.Items.Add("Sql3");
        }
        private void SetUpContextMenu()
        {
            MenuItem item1 = new MenuItem();
            item1.Header = "Remote1";
            item1.Click += AddToComboBox;
            item1.CommandParameter = "Remote1";
            MenuItem item2 = new MenuItem();
            item2.Header = "Remote2";
            item2.Click += AddToComboBox;
            item2.CommandParameter = "Remote2";
            MenuItem item3 = new MenuItem();
            item3.Header = "Remote3";
            item3.Click += AddToComboBox;
            item3.CommandParameter = "Remote3";
            
            context1.Items.Add(item1);
            context1.Items.Add(item2);
            context1.Items.Add(item3);
        }
        public void AddToComboBox(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            int index = cb1.Items.Add(item.CommandParameter);
            cb1.SelectedIndex = index;
        }
    }
