     public class RestrictedTextBox : TextBox
     {
        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(int), typeof(RestrictedTextBox), new PropertyMetadata(int.MaxValue));
        public RestrictedTextBox()
        {
            PreviewTextInput += RestrictedTextBox_PreviewTextInput;
        }
        public int MaxValue
        {
            get
            {
                return (int)GetValue(MaxValueProperty);
            }
            set
            {
                SetValue(MaxValueProperty, value);
            }
        }
        private void RestrictedTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int inputDigits;
            RestrictedTextBox box = sender as RestrictedTextBox;
            if (box != null)
            {
                if (!e.Text.All(Char.IsDigit))
                {
                    // Stops the text from being handled
                    e.Handled = true;
                }
                else if (int.TryParse(box.Text + e.Text, out inputDigits))
                {
                    if (inputDigits > MaxValue)
                        e.Handled = true;
                }
            }
        }
    }
