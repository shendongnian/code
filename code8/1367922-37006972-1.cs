    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            HostGrid.Children.Clear();
            switch(((MenuItem)e.OriginalSource).Name)
            {
                case "Home":
                    HostGrid.Children.Add(new UserControlHome());
                    break;
                case "Page1":
                    HostGrid.Children.Add(new UserControl1());
                    break;
                case "Page2":
                    HostGrid.Children.Add(new UserControl2());
                    break;
            }
        }
    }
