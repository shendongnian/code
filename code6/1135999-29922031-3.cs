    private Polyline currentPolyline;
    private void startDrawing(object sender, MouseButtonEventArgs e)
    {
        var canvas = (Canvas)sender;
        currentPolyline = new Polyline
        {
            Stroke = Color,
            StrokeThickness = StrokeThickness,
            StrokeStartLineCap = PenLineCap.Round,
            StrokeEndLineCap = PenLineCap.Round,
            StrokeLineJoin = PenLineJoin.Round
        };
        currentPolyline.Points.Add(e.GetPosition(canvas));
        canvas.Children.Add(currentPolyline);
    }
    private void stopDrawing(object sender, MouseButtonEventArgs e)
    {
        currentPolyline = null;
    }
    private void doDrawing(object sender, MouseEventArgs e)
    {
        if (currentPolyline != null)
        {
            currentPolyline.Points.Add(e.GetPosition((UIElement)sender));
        }
    }
