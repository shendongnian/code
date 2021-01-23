    private Brush stroke = Brushes.Red;
    private double strokeThickness = 10;
    private Path currentPath;
    private Point startPoint;
    private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var canvas = (Canvas)sender;
        if (canvas.CaptureMouse())
        {
            startPoint = e.GetPosition(canvas);
            currentPath = new Path
            {
                Data = new RectangleGeometry(new Rect(startPoint, startPoint)),
                Stroke = stroke,
                StrokeThickness = strokeThickness
            };
            canvas.Children.Add(currentPath);
        }
    }
    private void Canvas_MouseMove(object sender, MouseEventArgs e)
    {
        if (currentPath != null)
        {
            ((RectangleGeometry)currentPath.Data).Rect
                    = new Rect(startPoint, e.GetPosition((UIElement)sender));
        }
    }
    private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
    {
        ((UIElement)sender).ReleaseMouseCapture();
        currentPath = null;
    }
