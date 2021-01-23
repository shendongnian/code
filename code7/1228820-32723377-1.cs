    public class DrawingViewModel : INotifyPropertyChanged
    {
        private double _startX1;
        private double _endX2;
        private double _startY1;
        private double _endY2;
        // properties
        public double StartX1
        {
            get { return _startX1; }
            set
            {
                if (_startX1 != value)
                {
                    _startX1 = value;
                    OnPropertyChanged("StartX1");
                }
            }
        }
        public double EndX2
        {
            get { return _endX2; }
            set
            {
                if (_endX2 != value)
                {
                    _endX2 = value;
                    OnPropertyChanged("EndX2");
                }
            }
        }
        public double StartY1
        {
            get { return _startY1; }
            set
            {
                if (_startY1 != value)
                {
                    _startY1 = value;
                    OnPropertyChanged("StartY1");
                }
            }
        }
        public double EndY2
        {
            get { return _endY2; }
            set
            {
                if (_endY2 != value)
                {
                    _endY2 = value;
                    OnPropertyChanged("EndY2");
                }
            }
        }
        // end properties
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
