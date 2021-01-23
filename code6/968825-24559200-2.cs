    public partial class NumericPasswordBox : UserControl
    {
        #region Password 
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(NumericPasswordBox), new PropertyMetadata(null));
        #endregion
        #region MaxLength
        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MaxLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxLengthProperty =
            DependencyProperty.Register("MaxLength", typeof(int), typeof(NumericPasswordBox), new PropertyMetadata(100));
        
        #endregion
        public NumericPasswordBox()
        {
            InitializeComponent();
        }
        private void PasswordTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Password = PasswordTextBox.Text;
            //replace text by *
            PasswordTextBox.Text = Regex.Replace(Password, @".", "●");
            //take cursor to end of string
            PasswordTextBox.SelectionStart = PasswordTextBox.Text.Length;
        }
    }
