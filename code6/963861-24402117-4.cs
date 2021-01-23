    private void cMenuu_Opened(object sender, RoutedEventArgs e)
    {
      // Here, get the selected item from your grid and check the status
      var item = yourGridNameHere.SelectedItem;
    
      // Again: pseudo code to check the status
      if (item.Status == "reported")
      {
        Send.IsEnabled = false;
        Resend.IsEnabled = true;
      }
      else
      {
        // Something else, like enable the other menu items again
      }
    }
