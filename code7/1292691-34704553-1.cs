    PathFigure CalculateArrow(PathFigure pathfig, Point pt1, Point pt2)
        {
            Matrix matx = new Matrix();
            Vector vect = pt1 - pt2;
            vect.Normalize();
            vect *= ArrowLength;
            
            
            PolyLineSegment polyseg = pathfig.Segments[0] as PolyLineSegment;
            polyseg.Points.Clear();
            matx.Rotate(ArrowAngle / 2);
            //added code starts
           //places the position of the arrow on the midpoint
            pt2.X = (pt2.X + pt1.X) / 2;
            pt2.Y = (pt2.Y + pt1.Y) / 2;
            //added code ends
            pathfig.StartPoint = pt2 + vect * matx;
            polyseg.Points.Add(pt2);
            matx.Rotate(-ArrowAngle);
            polyseg.Points.Add(pt2 + vect * matx);
            pathfig.IsClosed = IsArrowClosed;
            return pathfig;
        }
