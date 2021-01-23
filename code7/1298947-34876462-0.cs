    var systemMediaControls = SystemMediaTransportControls.GetForCurrentView();
                systemMediaControls.ButtonPressed += systemMediaControls_ButtonPressed;
                systemMediaControls.IsPlayEnabled = true;
                systemMediaControls.IsPauseEnabled = true;
                systemMediaControls.IsNextEnabled = true;
                systemMediaControls.IsPreviousEnabled = true;
    async void systemMediaControls_ButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs args)
        {
            switch (args.Button)
            {
                case SystemMediaTransportControlsButton.Play:
                break;
            }
        }
