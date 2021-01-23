    class One : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
       
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                IsModelDirty = true;
                // PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public bool IsModelDirty { get; set; }
    }
