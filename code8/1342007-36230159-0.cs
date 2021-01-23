    private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if(e.Key < Windows.System.VirtualKey.Number0 || e.Key >= Windows.System.VirtualKey.Number9)
        {
            e.Handled = true;
        }
    }
