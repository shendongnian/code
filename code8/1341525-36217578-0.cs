        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                e.Handled = true;
                if(condition) //my condition is true so go back through the stack
                    rootFrame.GoBack();
                }
            }
        }
