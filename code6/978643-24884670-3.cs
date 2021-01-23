    // Create a Polyline.
    Polyline polyline1 = new Polyline();
    polyline1.Points.Add(new Point(25, 25));
    polyline1.Points.Add(new Point(0, 50));
    polyline1.Points.Add(new Point(25, 75));
    polyline1.Points.Add(new Point(50, 50));
    polyline1.Points.Add(new Point(25, 25));
    polyline1.Points.Add(new Point(25, 0));
    polyline1.Stroke = Brushes.Blue;
    polyline1.StrokeThickness = 10;
    
    // Create a RotateTransform to rotate 
    // the Polyline 45 degrees about its 
    // top-left corner.
    RotateTransform rotateTransform1 =
        new RotateTransform(45);
    polyline1.RenderTransform = rotateTransform1;
    
    // Create a Canvas to contain the Polyline.
    Canvas canvas1 = new Canvas();
    canvas1.Width = 200;
    canvas1.Height = 200;
    Canvas.SetLeft(polyline1, 75);
    Canvas.SetTop(polyline1, 50);
    canvas1.Children.Add(polyline1);
