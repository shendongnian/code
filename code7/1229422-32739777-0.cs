    Class CustomObject : INotifyPropertyChanged
    {
        private string _innerProperty;
        public string InnerProperty 
          {get { return _innerProperty; }
          {set 
             {
                  _innerProperty = value;
                  OnPropertyChanged("InnerProperty");
             }
          }
          // + the standard INotifyPropertyChanged stuff
          //   which is easy to find
    }
