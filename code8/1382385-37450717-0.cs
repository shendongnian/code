    class Person:INotifyPropertyChanged
    {
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { 
                _username= value; 
                OnPropertyChanged("UserName");
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }
    }
