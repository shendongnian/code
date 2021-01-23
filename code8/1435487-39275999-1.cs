    /// <summary>
    /// Initialize this instance.
    /// </summary>
    private void Initialize()
    {			
        this.AddView(_mapView as View);
        this.Drag += MapView_Drag;
    }
    void MapView_Drag(object sender, View.DragEventArgs e)
    {
        // React on different dragging events
        var evt = e.Event;
        switch (evt.Action)
        {
            case DragAction.Ended:
            case DragAction.Started:
            case DragAction.Location:
                e.Handled = true;
                break;
            case DragAction.Drop:
                // Try to get clip data
                var data = e.Event.ClipData;
                if (data != null)
                {
                    Guid thisOid = new Guid(data.GetItemAt(0).Text);
                    //find MapMarker using Guid
                    MapMarker marker = _markers.Find(x => x.Oid == thisOid);
                    if (marker != null)
                    {
                        float xCoord = evt.GetX();
                        float yCoord = evt.GetY() + (marker.Image.Height / 2); //middle of image offset
                        marker.Location = (sender as MapView).PointToCoordinate(Convert.ToSingle(xCoord), Convert.ToSingle(yCoord));
                    }
                }
                e.Handled = true;
                break;
        }
    }
    public GeoCoordinate PointToCoordinate(double PointX, double PointY)
    {
        double x, y;
        var fromMatrix = CurrentView.CreateFromViewPort(CurrentWidth, CurrentHeight);
        fromMatrix.Apply(PointX, PointY, out x, out y);
        return this.Map.Projection.ToGeoCoordinates(x, y);
    }
