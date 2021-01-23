    public class SearchRegion : INotifyPropertyChanged
    {
        public SearchRegion() { }
    
        public string RegionDesc { get; set; }
        public string Region { get; set; }
    
        bool _isChecked = false;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
