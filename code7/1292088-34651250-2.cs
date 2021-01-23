    public GenericPanel : INotifyPropertyChanged
    {
      private Brush _motionColor;
      public Brush motionColor { 
        get { return _motionColor; }; 
        set { 
          _motionColor = value; 
          OnPropertyChanged(); 
        }
      }
      /* ... the rest of your class ... */
      public event PropertyChangedEventHandler PropertyChanged;
      protected void OnPropertyChanged([CallerMemberName] string propertyName = null)  
      {        
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
