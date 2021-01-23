    private void text_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        popup.IsOpen = true;
        Rectangle.BeginAnimation(UIElement.OpacityProperty,
            new DoubleAnimation(1d, TimeSpan.FromSeconds(0.5)));
    }
    private void text_GotKeyboardFocus2(object sender, RoutedEventArgs e)
    {
        popup.IsOpen = false;
        text.Text = (sender as TextBox).Text;
        Rectangle.BeginAnimation(UIElement.OpacityProperty,
            new DoubleAnimation(0d, TimeSpan.FromSeconds(0.5)));
    }
