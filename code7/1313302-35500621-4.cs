    public class Model : INotifyPropertyChanged
    {
        private bool _isSelected;
        public string PHOTO { get; set; }
        public string NAME { get; set; }
        public string DISTANCE { get; set; }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    RaisePropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChanged = Volatile.Read(ref PropertyChanged);
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
