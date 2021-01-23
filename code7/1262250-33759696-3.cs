    public partial class MainWindow : Window
    {
        Window1 window1;//your subwindow
        public MainWindow()
        {
            InitializeComponent();
            window1 = new Window1();
        }
        private void buttonShow_Click(object sender, RoutedEventArgs e)//button to show subwindow
        {
            int[] testData = new int[5] { 1, 3, 5, 7, 9 };
            window1.ShowThis(testData);
        }
    }
