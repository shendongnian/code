     if (!ApplicationData.Current.LocalSettings.Values.Keys.Contains("Launched"))
     {
         rootFrame.Navigate(typeof(WelcomePage));
     }
     else
     {
         rootFrame.Navigate(typeof(MainPage));
     }
