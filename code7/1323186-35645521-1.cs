    private void btnHideAllButtons_Click(object sender, RoutedEventArgs e)
    {
       //Code to Hide all Buttons
    
       foreach (Button button in allButtons)
       {
            button.Visibility = Visibility.Visible;
       }
    }
