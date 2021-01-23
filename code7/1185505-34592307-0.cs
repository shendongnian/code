    class UserData:  INotifyPropertyChanged
        {
    
         public event PropertyChangedEventHandler PropertyChanged;
         
         private string _Title;
         public string Title
           {
            get
                {
                    return _Title;
                }
            set
                {
                 if (_Title != value)
                    {
                      _Title = value;
                      if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                        }
                    }
                }
            }
        }
