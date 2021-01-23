      public class NumericTextBox : TextBox
      {
    
        public NumericTextBox()
        {
          PreviewTextInput += NumericTextBox_PreviewTextInput;
        }
    
        void NumericTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
          e.Handled = !isTextAllowed(e.Text);
        }
     
        private static bool isTextAllowed(string text)
        {
          var regex = new Regex("[^0-9]+");
          return !regex.IsMatch(text);
        }
      }
