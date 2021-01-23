        private void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
                BasicGeoposition snPosition = new BasicGeoposition() { Latitude = 47.7356039173901, Longitude = -122.310697222129
    
                };
                Geopoint snPoint = new Geopoint(snPosition);
    
                // Create a XAML border.
                Grid grid = new Grid
                {
                    Width=100,
                    Height=100,
                    Background = new ImageBrush() {ImageSource= new BitmapImage(new Uri("ms-appx:///Assets/icon.png", UriKind.RelativeOrAbsolute)), Stretch = Stretch.UniformToFill}
                };
                  grid.ManipulationMode = ManipulationModes.TranslateX|ManipulationModes.TranslateY;
     grid.ManipulationCompleted += Grid_ManipulationCompleted;
                grid.ManipulationDelta +=Grid_ManipulationDelta;
                // Center the map over the POI.
                MapControl1.Center = snPoint;
                MapControl1.ZoomLevel = 14;
                CompositeTransform tran = new CompositeTransform();
                grid.RenderTransform = tran;
                // Add XAML to the map.
                MapControl1.Children.Add(grid);
                MapControl.SetLocation(grid, snPoint);
                MapControl.SetNormalizedAnchorPoint(grid, new Point(0.5, 0.5));
            }  
    
            private void Grid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
            {
                Grid grid = sender as Grid;
                CompositeTransform xform = grid.RenderTransform as CompositeTransform;
    
                
                xform.TranslateX += e.Delta.Translation.X;
                xform.TranslateY += e.Delta.Translation.Y;
                Rect point = grid.TransformToVisual(MapControl1).TransformBounds(new Rect(0,0, grid.Width, grid.Height));
        
                e.Handled = true;
                Geopoint gPoint;
                MapControl1.GetLocationFromOffset(new Point(point.X, point.Y), out gPoint);
                Debug.WriteLine(gPoint.Position.Latitude);
                Debug.WriteLine(gPoint.Position.Longitude);
            }
    
      private void Grid_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
            {
                Grid grid = sender as Grid;
                Rect point = grid.TransformToVisual(MapControl1).TransformBounds(new Rect(0, 0, grid.Width, grid.Height);
                Geopoint gPoint;
                MapControl1.GetLocationFromOffset(new Point(point.X, point.Y), out gPoint);
                Debug.WriteLine(gPoint.Position.Latitude);
                Debug.WriteLine(gPoint.Position.Longitude);
            }
