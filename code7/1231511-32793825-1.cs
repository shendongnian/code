    partial class MyDialog : Window {
    
        public MyDialog(String text) {
            InitializeComponent();
            DialogText = text;
        }
    
        public string DialogText {
            get { return MyTextBox.Text; }
            set { MyTextBox.Text = value; }
        }
    
        private void DoneButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
