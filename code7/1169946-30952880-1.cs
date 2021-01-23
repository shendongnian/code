    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = true;
            tbPopup.Focusable = true;
            Keyboard.Focus(tbPopup);
        }
        private void myPopup_LostFocus(object sender, RoutedEventArgs e)
        {
            tbOutsidePopup.Focusable = true;
            Keyboard.Focus(tbOutsidePopup);
        }
    }
