        partial class Window1 : Window, INotifyPropertyChanged
        {
          public event PropertyChangedEventHandler PropertyChanged;
        
          private string _listlength;
        
          public string Listlength
          {
            get { return _listlength; }
            set
            {
              if (value != _listlength)
              {
                 _listlength = value;
                 OnPropertyChanged("Listlength");
              }
            }
          }
    
    }
