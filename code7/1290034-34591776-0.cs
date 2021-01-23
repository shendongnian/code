    private bool IsTextAllowed(string text)
    {
         Regex regex = new Regex("[^0-9/]+"); 
         return !regex.IsMatch(text);
    }
    
    private void DatePicker_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
         e.Handled = !IsTextAllowed(e.Text);
    }
