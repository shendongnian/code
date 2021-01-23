    TextBox1.LostFocus += (s, e) => TextBox_LostFocus(s, e);
    TextBox1.TextChanged += (s, e) => TextBox_TextChanged(s, e);
    
    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
    // Your event handling procedure, Formatting, etc.
    }
    
    private void TextBox_TextChanged(object sender, RoutedEventArgs e)
    {
    // Your event handling procedure, Formatting, etc.
    }
