    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestClass testClass = new TestClass();
            testClass.Test = "Initial";
            Second second = new Second(testClass);
            second.ShowDialog();
            label.Content = testClass.Test; // It prints "Changed"
        }
    }
