    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // some logic
        // calendarPopup.IsOpen = false;
        calendarDialog.Hide();
    }
    private async void showCalndarButton_Click(object sender, RoutedEventArgs e)
    {
        // calendarPopup.IsOpen = true;
        await calendarDialog.ShowAsync();
    }
