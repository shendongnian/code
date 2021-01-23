        Point _drawingStart;
        bool _isDrawing;
        private void startDrawing(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _drawingStart = e.GetPosition((UIElement)sender);
            InitializePath();
            _isDrawing = true;
        }
        private void stopDrawing(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isDrawing = false;
        }
        private void doDrawing(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isDrawing)
            {
                AddPoint(e.GetPosition((UIElement)sender));
            }
        }
     private void AddPoint(Point newpoint)
     {
            LineSegment l = new LineSegment() { Point = newpoint };
            pathFigure.Segments.Add(l);
            pathFigure.StartPoint = (pathFigure.Segments.First() as LineSegment).Point;
        }
        PathFigure pathFigure;
        Path path;
        private void InitializePath()
        {
            path = new Path()
            {
                StrokeLineJoin = PenLineJoin.Bevel,
                StrokeDashCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeThickness = 100.0,
                Stroke = new SolidColorBrush(Colors.Red)
            };
            pathFigure = new PathFigure();
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = new PathFigureCollection();
            pathGeometry.Figures.Add(pathFigure);
            path.Data = pathGeometry;
            DrawingCanvas.Children.Add(path);
        }
