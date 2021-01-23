        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeftButtonDown += AssociatedObjectOnMouseLeftButtonDown;
            AssociatedObject.MouseLeftButtonUp += AssociatedObjectOnMouseLeftButtonUp;
            AssociatedObject.MouseMove += AssociatedObjectOnMouseMove;
        }
        private void AssociatedObjectOnMouseMove(object sender, MouseEventArgs e)
        {
            if (_shape != null && _shape.IsMouseCaptured)
            {
                _p2 = e.GetPosition(AssociatedObject);
                _shape.SetValue(Canvas.TopProperty, _p2.Y - _originalOffsetFromTop);
                _shape.SetValue(Canvas.LeftProperty, _p2.X - _originalOffsetFromLeft);
            }
        }
        private void AssociatedObjectOnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_shape == null) return;
            _shape.ReleaseMouseCapture();
            _shape = null;
        }
        private double GetDist(double originalValue, double newValue)
        {
            if (double.IsNaN(originalValue) || double.IsInfinity(originalValue))
                return Math.Abs(newValue - 0);
            return Math.Abs(newValue - originalValue);
        }
        private void AssociatedObjectOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _shape = e.OriginalSource as Shape;
            if (_shape != null)
            {
                _p1 = e.GetPosition(AssociatedObject);
                _shape.CaptureMouse();
                _originalOffsetFromTop = GetDist((double)_shape.GetValue(Canvas.TopProperty), _p1.Y);
                _originalOffsetFromLeft = GetDist((double)_shape.GetValue(Canvas.LeftProperty), _p1.X);
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseLeftButtonDown -= AssociatedObjectOnMouseLeftButtonDown;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObjectOnMouseLeftButtonUp;
            AssociatedObject.MouseMove -= AssociatedObjectOnMouseMove;
        }
 
