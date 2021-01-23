     private async void Pin_Tapped(object sender, TappedRoutedEventArgs e)
     {
         Geopoint geopoint = null;
         MainMap.GetLocationFromOffset(e.GetPosition(MainMap), out geopoint);
         Debug.WriteLine(geopoint.Position.Latitude + "," + geopoint.Position.Longitude);
     }
