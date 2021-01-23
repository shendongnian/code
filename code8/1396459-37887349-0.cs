      // init left point
                List<Point> boundariesCoords = new List<Point>();
                boundariesCoords.Add(new Point(_leftPadding, _topPadding));
    
    
     // final right point
                boundariesCoords.Add(new Point(_leftPadding + leftInsertionBox.Width + leftCoverBox.Width + bottomGlueBox.Width, _topPadding + topRect.Height + frontRect.Height + bottomRect.Height + backRect.Height + bottomGlueBox.Height));
    
    
         int totalX = 0, totalY = 0;
                    foreach (Point p in boundariesCoords)
                    {
                        totalX += p.X;
                        totalY += p.Y;
                    }
                    int centerX = totalX / boundariesCoords.Count;
                    int centerY = totalY / boundariesCoords.Count;
