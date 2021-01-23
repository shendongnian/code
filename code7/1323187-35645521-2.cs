    private void btnHideAllButtons_Click(object sender, RoutedEventArgs e)
    {
       foreach (Button button in allButtons)
       {
            button.Visibility = Visibility.Collapsed;
       }
       btnHideAllButtons.Visibility = Visibility.Visible;
    }
