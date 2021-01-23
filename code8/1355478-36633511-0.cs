     private async void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack && rootFrame != null)
            {
                rootFrame.GoBack();
            }
            else
            {
                var msg = new MessageDialog("Confirm Close");
                var okBtn = new UICommand("OK");
                var cancelBtn = new UICommand("Cancel");
                msg.Commands.Add(okBtn);
                msg.Commands.Add(cancelBtn);
                IUICommand result = await msg.ShowAsync();
                if (result != null && result.Label == "OK")
                {
                    Application.Current.Exit();
                }
            }
        }
