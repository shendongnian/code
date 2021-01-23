    private void questionTitle_textBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        TextBox tb = (sender as TextBox);
        if (tb != null)
        {
            if (!tb.IsFocused)
            {
                e.Handled = true;
                tb.Focus();
            }
        }
    }
    private void questionTitle_textBox_GotFocus(object sender, RoutedEventArgs e)
    {
        TextBox tb = (sender as TextBox);
        if (tb != null)
        {
            tb.SelectAll();
        }
    }
