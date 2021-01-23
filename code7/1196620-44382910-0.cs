        private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            bool status = false;
            if(rootFrame == null)
            {
                return;
            }
            if (rootFrame.SourcePageType.Name.Equals("POSummary") || rootFrame.SourcePageType.Name.Equals("AutoBinAllocation"))
            {
                e.Handled = true;
                status = true;
            }
            // Navigate back if possible, and if the event has not 
            // already been handled .
            if (rootFrame.CanGoBack && e.Handled == false && status == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }
