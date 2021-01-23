    public async void SetMapPolyline(List<BasicGeoposition> geoPositions)
    {
    	var polyLine = new MapPolyline { Path = new Geopath(geoPositions), StrokeThickness = 4, StrokeColor = (Color)App.Current.Resources["StravaRedColor"] };
    	BingMapControl.MapElements.Add(polyLine);
    
    	await BingMapControl.TrySetViewBoundsAsync(GeoboundingBox.TryCompute(geoPositions), null, MapAnimationKind.None);
    }
