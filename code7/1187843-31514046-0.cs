        Line line = new Line(); //New Line
        /*If Co-ords are equal to 0,0 reset them*/
        if (Position.X == 0 && Position.Y == 0)
        {
            NextPoint = Position
        }
        /*Colour of the line*/
        line.Stroke = Colour;
        /*Thickness Level*/
        line.StrokeThickness = 10;
        /*Make it less Jagged and Smoother by changing the Stroke Points*/
        line.StrokeDashCap = PenLineCap.Round;
        line.StrokeStartLineCap = PenLineCap.Round;
        line.StrokeEndLineCap = PenLineCap.Round;
        line.StrokeLineJoin = PenLineJoin.Round;
        /*Where to Draw the Line in terms of X and Y Positions*/
        line.X1 = Position.X;
        line.Y1 = Position.Y;
        line.X2 = Position.X + 0.01;
        line.Y2 = Position.Y + 0.01;
        /*Add The Line after Scaling*/
       Inkcanvas.SetLeft(line , Position.X - line.Width / 2);
       Ink canvas.SetTop(line, Position.Y - line.Height / 2);
        inkcanvas.Children.Add(line);
    }
