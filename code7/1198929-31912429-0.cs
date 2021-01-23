      protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
          HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }
        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
   
        Frame rootFrame = Window.Current.Content as Frame;
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }
    }
