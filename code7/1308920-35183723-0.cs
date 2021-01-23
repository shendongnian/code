    public class ImageViewModel : INotifyPropertyChanged
    {
        private Point _center;
        private int _radiusX;
        private int _radiusY;
        public Point Center
        {
            get
            {
                return _center;
            }
            set
            {
                if (_center != value)
                {
                    _center = value;
                    OnPropertyChanged();
                }
            }
        }
        public int RadiusX
        {
            get
            {
                return _radiusX;
            }
            set
            {
                if (_radiusX != value)
                {
                    _radiusX = value;
                    OnPropertyChanged();
                }
            }
        }
        public int RadiusY
        {
            get
            {
                return _radiusY;
            }
            set
            {
                if (_radiusY != value)
                {
                    _radiusY = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnUpdate(Point center, int radiusX, int radiusY)
        {
            Center = center;
            RadiusX = radiusX;
            RadiusY = radiusY;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
