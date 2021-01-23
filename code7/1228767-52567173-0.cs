      int click = 0;
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            click++;
            ((RadioButton)sender).IsChecked = click % 2 == 1 ;
            click %= 2;
        }
