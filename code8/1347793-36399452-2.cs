    public partial class MainWindow : Window
    {
        Class1 cs1;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = cs1 = new Class1();
        }
        private void button_Click(object sender, RoutedEventArgs e) 
        {
           cs1.TestProperty = "Test button";
        }
    }
