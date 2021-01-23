    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label element = new Label() { Content = "This is some example content" };
            panel.Children.Add(element);
        }
    }
