    private Point _p2;
        private Point _p1;
        private double _originalOffsetFromTop = double.NaN;
        private double _originalOffsetFromLeft = double.NaN;
        private Shape _shape;
        private void MyCanvas_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (_shape != null && _shape.IsMouseCaptured)
            {
                _p2 = e.GetPosition(MyCanvas);
                //var offsetX = _p2.X - _p1.X;
                //var offsetY = _p2.Y - _p1.Y;
                //TranslateTransform tf = new TranslateTransform(offsetX, offsetY);
                //_MyTestRect.RenderTransform = tf;
                _shape.SetValue(Canvas.TopProperty, _p2.Y - _originalOffsetFromTop);
                _shape.SetValue(Canvas.LeftProperty, _p2.X- _originalOffsetFromLeft);
            }
        }
        private void MyCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _shape = e.OriginalSource as Shape;
            if (_shape != null)
            {
                _p1 = e.GetPosition(MyCanvas);
                _shape.CaptureMouse();
                _originalOffsetFromTop = GetDist((double)_shape.GetValue(Canvas.TopProperty), _p1.Y);
                _originalOffsetFromLeft = GetDist((double)_shape.GetValue(Canvas.LeftProperty), _p1.X);
            }
        }
        private double GetDist(double originalValue, double newValue)
        {
            if (double.IsNaN(originalValue) || double.IsInfinity(originalValue))
                return Math.Abs(newValue - 0);
            return Math.Abs(newValue - originalValue);
        }
        private void MyCanvas_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if(_shape == null) return;
            _shape.ReleaseMouseCapture();
            _shape = null;
        }
