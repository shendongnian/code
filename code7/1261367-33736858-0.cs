        int coursenumber;
        public MainWindow()
        {
            InitializeComponent();
           
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool res = int.TryParse(textBox.Text, out coursenumber);
            if (res == true)
            {
                //success
            }
           
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Check if the key that was pressed was the Enter key.
            if (e.Key == Key.Enter)
            {
               label2.Content = coursenumber;
    
            }
        }
