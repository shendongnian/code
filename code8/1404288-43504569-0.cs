        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isInDrag) return;
            _currentPoint = e.GetPosition(null);
            //This is change to the position that we want to apply
            Point delta = new Point();
            delta.X = _currentPoint.X - _anchorPoint.X;
            delta.Y = _currentPoint.Y - _anchorPoint.Y;
            //Calculate user control edges
            var leftEdge   = Margin.Left + _transform.X + delta.X;
            var topEdge    = Margin.Top + _transform.Y + delta.Y;
            var rightEdge  = Width + label.Margin.Left + _transform.X + delta.X;
            var bottomEdge = Height + label.Margin.Top + _transform.Y + delta.Y;
            //Set the delta to 0 if it goes over _parentGrid edges
            if (leftEdge < 0) delta.X = 0;
            if (topEdge  < 0) delta.Y = 0;
            if (rightEdge  > _parentGrid.Width)  delta.X = 0;
            if (bottomEdge > _parentGrid.Height) delta.Y = 0;
            //Apply the delta to the user control
            _transform.X += delta.X;
            _transform.Y += delta.Y;
            RenderTransform = _transform;
            _anchorPoint = _currentPoint;
        }
