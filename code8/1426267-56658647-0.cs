    PointF[] changedPoints = Refpath.PathData.Points;
    byte[] pointTypes = Refpath.PathData.Types;
    List<PointF> OriginalPoints = new List<PointF>();
    PointF currentPoint = new Point();
    int MyCoffe = 0;
    Refpath.PathPoints
            .ToList()
                .ForEach(
                    i =>
                    {    
                        currentPoint = new PointF
                        {
                            X = i.X,
                            Y = i.Y
                        };
                        OriginalPoints.Add(currentPoint);
                        if (pointTypes[MyCoffe]==3)
                        { 
                            // it's a curve, do something, like add text caption, etc...
                            changedPoints[MyCoffe].X -= 100; 
                            changedPoints[MyCoffe].Y -= 100;
                            // etc...
                        }
                        changedPoints[MyCoffe].X += 100; // if you want to change value
                        changedPoints[MyCoffe].Y += 100;
                        MyCoffe ++;
                    }
                );
    GraphicsPath newPath = new GraphicsPath(changedPoints, pointTypes);
