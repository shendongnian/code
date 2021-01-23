    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
        }
        bool WindowFlag = false;
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Window TestWindows = new Window();
            TestWindows.Closing += TestWindows_Closing;
           
            if (WindowFlag == true)
            {               
                MessageBox.Show("The Window is already opened");
            }
            else
            {
                TestWindows.Show();
                WindowFlag = true;
            }
        }
        private void TestWindows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WindowFlag = false;
        }
    }
