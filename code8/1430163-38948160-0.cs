       Frame rootFrame = Window.Current.Content as Frame;
       if (rootFrame != null)
       {
           if (rootFrame.CanGoBack)
           {
               e.Handled = true;
               rootFrame.GoBack();
           }
           else
           {
               Application.Current.Exit();
           }
       }
    }
