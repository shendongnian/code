    private void AddPlayerSix(object sender, TappedRoutedEventArgs e)
         {
            PlayerSixName.Visibility = Visibility.Visible;
            PlayerSixTag.Visibility = Visibility.Visible;
            // Your code (not working)
            //AddPlayerSixButton.Visibility = Visibility.Collapsed;
            //MinusPlayerSixButton.Visibility = Visibility.Visible;
            // New code (works)
            PlayerFiveButtons.Visibility = Visibility.Collapsed;
            PlayerSixButtons.Visibility = Visibility.Visible;
        }
