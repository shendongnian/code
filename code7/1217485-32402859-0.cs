    void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.Content is MainPage)
            {
                rootFrame.BackStack.Clear();
            }
            else if (rootFrame != null && rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
            e.Handled = true;
    }
