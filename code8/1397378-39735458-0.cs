    GMapRoute line_layer;
    GMapOverlay line_overlay
    line_layer = new GMapRoute("single_line");
    line_layer.Stroke = new Pen(Brushes.Black, 2); //width and color of line
    line_overlay.Routes.Add(line_layer);
    gMapControl1.Overlays.Add(line_overlay)
    //Once the layer is created, simply add the two points you want
    line_layer.Points.Add(new PointLatLng(lat, lon));
    line_layer.Points.Add(new PointLatLng(lat2, lon2));
    //Note that if you are using the MouseEventArgs you need to use local coordinates and convert them:
    line_layer.Points.Add(gMapControl1.FromLocalToLatLng(e.X, e.Y));
    //To force the draw, you need to update the route
    gMapControl1.UpdateRouteLocalPosition(line_layer);
    //you can even add markers at the end of the lines adding markers to the same layer:
    GMapMarker marker_ = new GMarkerCross(p);
    line_overlay.Markers.Add(marker_);
