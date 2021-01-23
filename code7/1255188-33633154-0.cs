    private void w_Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Point lineEnd = e.GetPosition(w_Canvas);
                    Line l = new Line();
                    
                    LINE.Add(new Tuple<double, double, double, double>(lineStartPoint.X, lineStartPoint.Y, lineEnd.X, lineEnd.Y));
                    l.X1 = LINE[LINE.Count - 1].Item1;
                    l.Y1 = LINE[LINE.Count - 1].Item2;
                    l.X2 = LINE[LINE.Count - 1].Item3;
                    l.Y2 = LINE[LINE.Count - 1].Item4;
                    l.Stroke = brush;
                    l.StrokeThickness = 3;
                    w_Canvas.Children.Add(l);
                    lineStartPoint = lineEnd;
                }
            }
        }
        private void w_Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
        }
    }
