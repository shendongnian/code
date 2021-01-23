    class Ressource : INotifyPropertyChanged
    {
        private String _downloaded;
        public string downloaded
        {
            get { return _downloaded; }
            set
            {
                _downloaded= value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("downloaded"));
            }
        }
    }
