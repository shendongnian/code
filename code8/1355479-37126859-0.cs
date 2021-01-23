    protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            //......
            DeviceGestureService.GoBackRequested += (s, e) =>
            {
                e.Handled = true;
                if (NavigationService.CanGoBack())
                {
                    NavigationService.GoBack();
                }
                else
                {
                    // PUT YOUR LOGIC HERE (Confirmation dialog before exit)
                    Application.Current.Exit();
                }
            };
            //......
         }
