    public partial class MainWindow : Window
    {
        public class MyInfo
        {
            public string Name { get; set; }
            public string Ssn { get; set; }
            public string Dob { get; set; }
        }
        private MyInfo _myInfo;
        public MainWindow()
        {
            InitializeComponent();
            _myInfo = new MyInfo();
            _myInfo.Name = "My name";
            this.DataContext = _myInfo;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("My name is '" + _myInfo.Name + "'");
        }
    }
