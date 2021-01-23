        private void elementWrapper_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_mouseHandlingMode != MouseHandlingMode.Dragging)
                return;
            SelectableElement element = (SelectableElement)sender;
            Point curContentPoint = e.GetPosition(content);
            //Vector elementDragVector = curContentPoint - _origContentMouseDownPoint;
            _origContentMouseDownPoint = curContentPoint;
            //double destinationLeft = Canvas.GetLeft(element) + elementDragVector.X;
            //double destinationTop = Canvas.GetTop(element) + elementDragVector.Y;
            double destinationLeft = curContentPoint.X - element.ActualWidth / 2;
            double destinationTop = curContentPoint.Y - element.ActualHeight / 2;
            if (SnapToGrid)
            {
                if (XGridVisible)
                {
                    foreach (Line l in _gridXLines)
                        l.StrokeThickness = 1;
                    Line nearest = GetNearestXGridLine((int)curContentPoint.X);
                    if (Math.Abs(curContentPoint.X - nearest.X1) < XGridStep * 0.2)
                    {
                        destinationLeft = nearest.X1 - element.ActualWidth / 2;
                        nearest.StrokeThickness = 3;
                    }
                }
                if (YGridVisible)
                {
                    foreach (Line l in _gridYLines)
                        l.StrokeThickness = 1;
                    Line nearest = GetNearestYGridLine((int)curContentPoint.Y);
                    if (Math.Abs(curContentPoint.Y - nearest.Y1) < YGridStep * 0.2)
                    {
                        destinationTop = nearest.Y1 - element.ActualHeight / 2;
                        nearest.StrokeThickness = 3;
                    }
                }
            }
            if (destinationLeft < 0)
                destinationLeft = 0;
            if (destinationLeft > content.ActualWidth - element.ActualWidth)
                destinationLeft = content.ActualWidth - element.ActualWidth;
            if (destinationTop < 0)
                destinationTop = 0;
            if (destinationTop > content.ActualHeight - element.ActualHeight)
                destinationTop = content.ActualHeight - element.ActualHeight;
            Canvas.SetLeft(element, destinationLeft);
            Canvas.SetTop(element, destinationTop);
            element.ElementContent.Position.X = curContentPoint.X;
            element.ElementContent.Position.Y = curContentPoint.Y;
            e.Handled = true;
        }
        private Line GetNearestXGridLine(int xpos)
        {
            return _gridXLines.OrderBy(gl => Math.Abs((int)gl.X1 - xpos)).First();
        }
        private Line GetNearestYGridLine(int Ypos)
        {
            return _gridYLines.OrderBy(gl => Math.Abs((int)gl.Y1 - Ypos)).First();
        }
