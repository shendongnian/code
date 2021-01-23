         BitmapImage myImage1;
         myImage1 = new BitmapImage(new Uri("/Assets/Images/pushpin-google-hi.png", UriKind.RelativeOrAbsolute));
         var image = new Image();
         image.Width = 50;
         image.Height = 50;
         image.Opacity = 100;
         image.Source = myImage1;
        
         var mapOverlay = new MapOverlay();
         mapOverlay.Content = image;
         mapOverlay.GeoCoordinate = new GeoCoordinate(lats, lons);
         var mapLayer = new MapLayer();
         mapLayer.Add(mapOverlay);
         MyMap.Layers.Add(mapLayer);
         MyMap.SetView(new GeoCoordinate(lats, lons), 16);
