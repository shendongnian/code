    class Class1 : INotifyPropertyChanged
    {
        private string _pollo = "";
        public string pollo
        {
            get { return _pollo; }
            set
            {
                _pollo = value;
                OnPropertyChanged();
            }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
