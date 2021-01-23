       PathGeometry pathGeometry = new PathGeometry();
       PathFigure pathFigure = new PathFigure();
       pathFigure.StartPoint = start;
       ArcSegment arc = new ArcSegment(end, new Size(radiusX, radiusY), 0.0, large, d, true);  //large & d corresponds to size & direction
       pathFigure.Segments.Add(arc);
       
       //line segment takes the path to the origin
       LineSegment line = new LineSegment(new Point(originX, originY), true);
       pathFigure.Segments.Add(line );
    
       pathGeometry.Figures.Add(pathFigure);
       SolidColorBrush fill = new SolidColorBrush(color);
       drawingContext.DrawGeometry(fill, pen, pathGeometry);
