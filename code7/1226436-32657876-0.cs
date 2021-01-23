    #if WINDOWS_PHONE_APP
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += (s, args) =>
                {
                    if (!rootFrame.CanGoBack)
                    {
                        return;
                    }
    
                    // Allow back navigation using Back button
                    args.Handled = true;
                    rootFrame.GoBack();
                };     
    #endif
