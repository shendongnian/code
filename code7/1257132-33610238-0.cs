    public partial class MainWindow : Window
    {
        Window1 window1;
        public MainWindow()
        {
            InitializeComponent();
            window1 = new Window1();
            window1.IsVisibleChanged += Window1_IsVisibleChanged;
        }
        private void Window1_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            buttonCollapsed.Visibility = window1.Visibility;//change the visibility of your button
        }
        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            window1.Show();//show subwindow
        }
    }
