    public partial class MainWindow : Window
    {
        Window1 window1;
        public MainWindow()
        {
            InitializeComponent();
            window1 = new Window1();
            window1.IsVisibleChanged += Window1_IsVisibleChanged;
            this.Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();//will close all windows
        }
        private void Window1_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            buttonCollapsed.Visibility = window1.Visibility;
        }
        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            window1.Show();
        }
