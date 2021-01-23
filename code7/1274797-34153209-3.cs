    void write(FreeHandShape freeHandShape, Matrix transform)
    {
       write(freeHandShape.Paths, transform);
    }
    
    void write(FreeHandPathCollection paths, Matrix transform)
    {
       foreach (var path in paths)
          write(path, transform);
    }
    
    void write(FreeHandPath path, Matrix transform)
    {
       foreach (var segment in path.Segments)
       {
          if (segment is FreeHandStartSegment)
          {
             var s = (FreeHandStartSegment)segment;
             Console.Write("M {0} ", write(s.X, s.Y, transform));
          }
          else if (segment is FreeHandLineSegment)
          {
             var s = (FreeHandLineSegment)segment;
             Console.Write("L {0} ", write(s.X1, s.Y1, transform));
          }
          else if (segment is FreeHandBezierSegment)
          {
             var s = (FreeHandBezierSegment)segment;
             Console.Write("C {0} {1} {2} ",
                write(s.X1, s.Y1, transform),
                write(s.X2, s.Y2, transform),
                write(s.X3, s.Y3, transform));
             }
          }
    
          if (path.Closed)
             Console.Write("Z ");
       }
    }
    
    string write(double x, double y, Matrix transform)
    {
       PointF[] points = { new PointF((float)x, (float)y) };
       transform.TransformPoints(points);
       return String.Format("{0} {1}", points[0].X, points[0].Y);
    }
