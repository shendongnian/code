        public partial class MainWindow : Window
        { 
           string CurrentString = null;
           string modifiedstring = null;
          public MainWindow()
          {
              InitializeComponent();
           }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            string value = textBox.Text.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            if (null != CurrentString)
            {
                if (CurrentString.Contains(value))
                {
                    StringBuilder newstring = new StringBuilder();
                    foreach (char c in CurrentString)
                    {
                        
                        if (value.ToLower().Equals(c.ToString()))
                        {
                            newstring.Append(value);
                        }
                        else
                        {
                            newstring.Append("?");
                        }
                    }
                    modifiedstring = newstring.ToString();
                    text1.Text = modifiedstring;
                   
                }
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var textBox = sender as TextBox;
                string value = textBox.Text.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
                CurrentString = value;
                StringBuilder newstring = new StringBuilder();
                for (int i = 0; i < value.Length; i++)
                {
                    newstring.Append("?");
                }
                textBox.Text = newstring.ToString();
            }
        }
            }
        }
