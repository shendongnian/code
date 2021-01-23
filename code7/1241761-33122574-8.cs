            private void RightMouseUp(Point obj)
        {
            _originalPoint = obj;
            _currentOffsetByX = GetDist(_currentOffsetByX, obj.X);
            _currentOffsetByY = GetDist(_currentOffsetByY, obj.Y);
        }
        private void RightMouseDown(Point obj)
        {
            _originalPoint = obj;
            _currentOffsetByX = GetDist(_currentOffsetByX, obj.X);
            _currentOffsetByY = GetDist(_currentOffsetByY, obj.Y);
        }
        private void MouseMoved(Point obj)
        {
            TranslateTransformX = obj.X - _currentOffsetByX;
            TranslateTransformY = obj.Y - _currentOffsetByY;
        }
        private double GetDist(double originalValue, double newValue)
        {
            if (double.IsNaN(originalValue) || double.IsInfinity(originalValue))
                return Math.Abs(newValue - 0);
            return Math.Abs(newValue - originalValue);
        }
        public double TranslateTransformY
        {
            get { return _translateTransformY; }
            set
            {
                _translateTransformY = value;
                OnPropertyChanged();
            }
        }
        public double TranslateTransformX
        {
            get { return _translateTransformX; }
            set
            {
                _translateTransformX = value;
                OnPropertyChanged();
            }
        }
