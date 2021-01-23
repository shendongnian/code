    private void questionTitle_textBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        TextBox tb = (sender as TextBox);
        if (tb != null)
        {
            if (!tb.IsFocused)
            {
                e.Handled = true;
                tb.Focus();
                tb.SelectAll();
            }
        }
    }
