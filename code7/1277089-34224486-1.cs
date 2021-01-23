    public partial class Second : Window
    {
        TestClass testClass;
        public Second(TestClass sent)
        {
            InitializeComponent();
            testClass = sent;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            testClass.Test = "Changed"; // Change the value
        }
    }
