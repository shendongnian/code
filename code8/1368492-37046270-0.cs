        private void HelpPopup_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsOpen"))
            {
                //re-try opening
                try {
                    Popup.IsOpen = (sender as HelpTip).IsOpen;
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    Canvas parent = Popup.Parent as Canvas;
                    Popup.IsOpen = false;
                    parent.Children.Remove(Popup);
                    Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                        Popup.IsOpen = true;
                        parent.Children.Add(Popup);
                        
                        //known method of updating position (for some reason it was incorrectly positioned on open)
                        var offset = Popup.HorizontalOffset;
                        Popup.HorizontalOffset = offset + 1;
                        Popup.HorizontalOffset = offset;
                    }), DispatcherPriority.SystemIdle);
                    
                }
            }
        }
