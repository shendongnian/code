        void pp_StylusDown(Object sender, StylusEventArgs e)
        {
            if (sender != null)
            {
                //Capture the touch device (i.e. finger on the screen)
                e.StylusDevice.Capture(sender as Pushpin);
            }
        }
        void pp_StylusUp(Object sender, StylusEventArgs e)
        {
            var device = e.StylusDevice;
            if (sender != null && device.Captured == sender as Pushpin)
            {
                (sender as Pushpin).ReleaseStylusCapture();
                PushPinUpOrDown(sender, true);
                e.Handled = true;
            }
        }
