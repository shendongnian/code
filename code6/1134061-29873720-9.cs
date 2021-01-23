    class DataItem : INotifyPropertyChanged
    {
        private string _vmName;
        private bool _isChecked1;
        private bool _isChecked2;
        public string VmName
        {
            get { return _vmName; }
            set { _vmName = value; OnPropertyChanged(); }
        }
        public bool IsChecked1
        {
            get { return _isChecked1; }
            set { _isChecked1 = value; OnPropertyChanged(); }
        }
        public bool IsChecked2
        {
            get { return _isChecked2; }
            set { _isChecked2 = value; OnPropertyChanged(); }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
