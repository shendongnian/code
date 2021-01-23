    private void _datePicker_OnLostFocus(object sender, RoutedEventArgs e)
    {
        DatePicker picker = sender as DatePicker;
        if (!picker.IsKeyboardFocusWithin)
        {
            System.Diagnostics.Debug.WriteLine("LostFocuse");
        }
    }
