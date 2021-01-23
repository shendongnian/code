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
          public event PropertyChangedEventHandler PropertyChanged;
          public void OnPropertyChanged(PropertyChangedEventArgs e)
          {
             if (PropertyChanged != null)
            {
               PropertyChanged(this, e);
            }
          }
    }
