    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.Closing += Window1_Closing;
        }
        private void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(sender is Window1)
            {
                e.Cancel = true;//Cancel the closing
                this.Hide();
            }
        }
        private void buttonHide_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();//hide your window --> IsVisibilityChanged-Event will be raised
        }
    }
