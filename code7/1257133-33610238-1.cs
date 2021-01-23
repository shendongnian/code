    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void buttonHide_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();//hide your window --> IsvisibilityChanged-Event will be raised
        }
    }
