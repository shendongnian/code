    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GoForward(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Forward");
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Backward");
        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.ForwardButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                e.Handled = true;
            }
            if (e.Key == Key.Back)
            {
                this.BackwardButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                e.Handled = true;
            }
        }
    }
