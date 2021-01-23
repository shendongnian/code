    private void TextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        (sender as TextBox).Visibility = Visibility.Collapsed;
    }
    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        textBox.Visibility = Visibility.Visible;
    }
