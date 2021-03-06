    public class LineViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isAutoScale { get; set; }
        private double _scale { get; set; }
        public bool IsAutoScale 
        {
            get { return _isAutoScale; }
            set
            {
                if (value == _isAutoScale ) return;
                _isAutoScale = value;
                OnPropertyChange("IsAutoScale");
                OnPropertyChange("IsReadOnly");
            }
        }
        public double Scale
        {
            get { return _scale; }
            set
            {
                if (value == _scale) return;
                _scale= value;
                OnPropertyChange("Scale");
            }
        }
        public bool IsReadOnly => !IsAutoScale;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
