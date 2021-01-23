    richWindow.Loaded +=
    {
         loadedButton.IsEnabled = false;
     };
    
    richWindow.Closing +=
    {
        loadedButton.IsEnabled = true;
     }
