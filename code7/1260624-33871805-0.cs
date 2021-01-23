    public partial class HomeFeed : BaseControl
    {
        public HomeFeed()
        {
            InitializeComponent();
        }
        private bool IsDragging
        {
            get { return _isDragging; }
            set
            {
                var start = _isDragging && !value;
                _isDragging = value;
                if (start)
                {
                    new Thread(x =>
                    {
                        var c = 0;
                        while (ApplyVelocity())
                        {
                            c++;
                            Thread.Sleep(15);
                        }
                    }).Start();
                }
            }
        }
        private Point _mousePosition;
        private Velocity _velocity = new Velocity();
        private bool _isDragging;
        private void HomeScrollViewer_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsDragging = true;
            _velocity.Reset();
            _mousePosition = e.GetPosition(this);
            e.Handled = true;
        }
        private void HomeScrollViewer_OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (!IsDragging) return;
            
            var pos = e.GetPosition(this);
            var y = pos.Y - _mousePosition.Y;
            if (y == 0)
            {
                return;
            }
            _velocity.TryUpdate(y);
            HomeScrollViewer.ScrollToVerticalOffset(HomeScrollViewer.VerticalOffset - y);
            _mousePosition = pos;
        }
        private void HomeScrollViewer_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!IsDragging) return;
            IsDragging = false;
            e.Handled = true;
        }
        private void HomeScrollViewer_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (!IsDragging) return;
            IsDragging = false;
            e.Handled = true;
        }
        private bool ApplyVelocity()
        {
            if (IsDragging || _velocity.Value == 0)
            {
                return false;
            }
            Dispatcher.BeginInvoke(new Action(() => HomeScrollViewer.ScrollToVerticalOffset(HomeScrollViewer.VerticalOffset - _velocity.Value)));
            var size = Math.Abs(_velocity.Value);
            var sign = size / _velocity.Value;
            _velocity.Value = sign * Math.Max(0, Math.Min(size*0.95, size - 1));
            return true;
        }
    }
    public class Velocity
    {
        private readonly int _timespan;
        public double Value { get; set; }
        public DateTime SetAt { get; set; }
        public Velocity(int timespan = 1000)
        {
            _timespan = timespan;
            Value = 0;
            SetAt = DateTime.Now;
        }
        public void TryUpdate(double value)
        {
            if (value == 0)
            {
                return;
            }
            if (SetAt.Add(TimeSpan.FromMilliseconds(_timespan)) > DateTime.Now)
            {
                SetAt = DateTime.Now;
                Value = value;
                return;
            }
            if (value*Value < 0)
            {
                SetAt = DateTime.Now;
                Value = value;
                return;
            }
            if (Math.Abs(value) > Math.Abs(Value))
            {
                SetAt = DateTime.Now;
                Value = value;
                return;
            }
        }
        public void Reset()
        {
            Value = 0;
            SetAt = DateTime.Now;
        }
    }
