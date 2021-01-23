     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private string text { get; set; }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            text=((TextBox)sender).Text;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            /// whatever you will do 
        }
    }
    }
