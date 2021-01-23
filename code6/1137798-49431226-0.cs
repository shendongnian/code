    public delegate void SwipedEventHandler(ISwipeListener sender, SwipedEventArgs e);
    public class SwipedEventArgs : EventArgs
    {
        readonly double _x;
        public double X => _x;
        readonly double _y;
        public double Y => _y;
        readonly View _view;
        public View View => _view;
        public SwipedEventArgs(View view, double x, double y)
        {
            _view = view;
            _x = x;
            _y = y;
        }
    }
    public interface ISwipeListener
    {
        event SwipedEventHandler SwipedDown;
        event SwipedEventHandler SwipedLeft;
        event SwipedEventHandler SwipedNothing;
        event SwipedEventHandler SwipedRight;
        event SwipedEventHandler SwipedUp;
        double TotalX
        {
            get;
        }
        double TotalY
        {
            get;
        }
    }
    public class SwipeListener : PanGestureRecognizer, ISwipeListener
    {
        public event SwipedEventHandler SwipedDown;
        public event SwipedEventHandler SwipedLeft;
        public event SwipedEventHandler SwipedNothing;
        public event SwipedEventHandler SwipedRight;
        public event SwipedEventHandler SwipedUp;
        double _totalX = 0, _totalY = 0;
        public double TotalX => _totalX;
        public double TotalY => _totalY;
        readonly View _view;
        public SwipeListener(View view) : base()
        {
            _view = view;
            _view.GestureRecognizers.Add(this);
            PanUpdated += OnPanUpdated;
        }
        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    try
                    {
                        _totalX = e.TotalX;
                        _totalY = e.TotalY;
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.Message);
                    }
                    break;
                case GestureStatus.Completed:
                    if (_totalX < 0 && Math.Abs(_totalX) > Math.Abs(_totalY))
                    {
                        OnSwipedLeft(_totalX, _totalY);
                    }
                    else if (_totalX > 0 && _totalX > Math.Abs(_totalY))
                    {
                        OnSwipedRight(_totalX, _totalY);
                    }
                    else if (_totalY < 0 && Math.Abs(_totalY) > Math.Abs(_totalX))
                    {
                        OnSwipedUp(_totalX, _totalY);
                    }
                    else if (_totalY > 0 && _totalY > Math.Abs(_totalX))
                    {
                        OnSwipedDown(_totalX, _totalY);
                    }
                    else OnSwipedNothing(_totalX, _totalY);
                    break;
            }
        }
        protected virtual void OnSwipedDown(double x, double y)
            => SwipedDown?.Invoke(this, new SwipedEventArgs(_view, x, y));
        protected virtual void OnSwipedLeft(double x, double y)
            => SwipedLeft?.Invoke(this, new SwipedEventArgs(_view, x, y));
        protected virtual void OnSwipedNothing(double x, double y)
            => SwipedNothing?.Invoke(this, new SwipedEventArgs(_view, x, y));
        protected virtual void OnSwipedRight(double x, double y)
            => SwipedRight?.Invoke(this, new SwipedEventArgs(_view, x, y));
        protected virtual void OnSwipedUp(double x, double y)
            => SwipedUp?.Invoke(this, new SwipedEventArgs(_view, x, y));
    }
