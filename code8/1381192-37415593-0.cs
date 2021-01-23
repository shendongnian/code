    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            //Or call Close
            //this.Close();
            MessageBox.Show("TEST");
            this.Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Window_Closing");
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Window_Closed");
        }
    }
