    public GenericPanel : INotifyPropertyChanged
    {
      private Brush _motionColor;
      public Brush motionColor { 
        get { return _motionColor; }; 
        set { 
          _motionColor = value; 
          OnPropertyChanged("motionColor"); 
        }
      }
      /* ... the rest of your class ... */
      public event PropertyChangedEventHandler PropertyChanged;
      protected void OnPropertyChanged(string propertyName)  
      {
        var handle = PropertyChanged;
        if(handle != null) 
          handle(this, new PropertyChangedEventArgs(propertyName));
      }
    }
