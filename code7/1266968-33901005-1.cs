     private void ToggleButton_Checked(object sender, RoutedEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("INFO:  ToggleButton_Checked called by {0}", sender);
            }
    
            private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("INFO:  ToggleButton_Unchecked called by {0}", sender);
            }
    
            private void ToggleButton_GotFocus(object sender, RoutedEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("INFO:  ToggleButton_GotFocus called by {0}", sender);
                (sender as ToggleButton).IsChecked = true;
            }
