        private void Ellipse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            locationInfo.Text = "Location info here";
            if (locationInfoGrid.Visibility == Visibility.Visible)
                locationInfoGrid.Visibility = Visibility.Collapsed;
            else
                locationInfoGrid.Visibility = Visibility.Visible;
        }
