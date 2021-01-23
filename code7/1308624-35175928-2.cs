    public class File:INotifyPropertyChanged
    {
        private Guid _FileID;
        public Guid FileID
        {
            get
            {
                return _FileID;
            }
            set 
            {
                _FileID = value;
                OnPropertyChanged("FileID");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }        
    }
  
