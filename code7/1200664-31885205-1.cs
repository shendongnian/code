    public class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = SynchronizationContext.Current;
            Task.Run(() => context.Post(state => Button.Content = "Hello World!"));
        }
    }
