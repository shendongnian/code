    namespace Test.Sandbox
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            //Example 1: 
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                Log.Debug();
                Log.Debug("button1 Clicked");
                Log.Debug("Fake Error Occured", new Exception("Fake Error"));
            }
            //Example 2:
            private void button2_Click(object sender, RoutedEventArgs e)
            {
                Log.Config.Level = Level.Error; // Set error level (updates logconfig.xml)
                Log.Debug(); //Does not get written because Level has been set to 'Error', above
                Log.Error();
                Log.Error("This is an Error");
                Log.Error(new Exception("Fake Error 2"));
            }
            
        }
    }
