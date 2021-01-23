    public partial class Window1 : Window
    {
        private MyViewModel vm;
        public Window1()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vm = new MyViewModel();
            DataContext = vm;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.WatchersGrid.Rows[0]["IsInRange"] = !(bool)vm.WatchersGrid.Rows[0]["IsInRange"];
        }
    }
