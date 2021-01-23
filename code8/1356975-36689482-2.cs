    public class comboItem : INotifyPropertyChanged
    {
        public string dayofweek { get; set; }
    
        private bool _ischecked;
    
        public bool ischecked
        {
            get
            {
                return _ischecked;
            }
            set
            {
                if (value != _ischecked)
                {
                    _ischecked = value;
                    OnPropertyChanged();
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
