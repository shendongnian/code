    public string NextSynchronization
    {
        get
        {
            return nextSync;
        }
        set
        {
            nextSync = value;
            OnPropertyChanged("NextSynchronization");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
