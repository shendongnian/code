    public class MyInfo
    {
        public string Name { get; set; }
        public string Ssn { get; set; }
        public string Dob { get; set; }
    } 
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MyInfo();
        }
        ...
