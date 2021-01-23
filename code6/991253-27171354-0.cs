     static MainPage()
            {
                HardwareButtons.BackPressed += (sender, args) =>
                {
                    var frame = Window.Current.Content as Frame;
                    if (frame != null && frame.CanGoBack)
                    {
                        frame.GoBack();
                        args.Handled = true;
                    }
                };
            }
