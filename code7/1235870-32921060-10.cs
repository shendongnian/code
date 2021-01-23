    class FolderStatusViewModel:INotifyPropertyChanged
    {
        string _status;
        string _folder;
        private void Changed(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                Changed("Status");
            }
        }
        public string Folder { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
