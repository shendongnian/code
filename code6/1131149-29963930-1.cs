    var Event = new PolygonAnnotation();
    Event.Layer = AnnotationLayer.BelowAxes;
    Event.StrokeThickness = 5;
    Event.Stroke = OxyColor.FromRgb(0, 0, 255);
    Event.LineStyle = LineStyle.Automatic;
    Event.Points.Add(new DataPoint(X, Y));
    Event.Points.Add(new DataPoint(X, Y));            
    Event.Points.Add(new DataPoint(X, Y));
    Event.Points.Add(new DataPoint(X, Y));
