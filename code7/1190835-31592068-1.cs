    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void raiseEventFromSecondPage_EventHandler()
        {
             MessageBox.Show("MAINWINDOW Event Fired");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
             SecondPage sp = new SecondPage();
             sp.raiseEventFromSecondPage += raiseEventFromSecondPage_EventHandler();
             sp.Show();
        }
    }
