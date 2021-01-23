    public class TwoStringClass: INotifyPropertyChanged
    {
    
      private string _String1;
      private string _ColorHex;
    
      public string String1
      {
        get
        {
          return _String1;
        }
        set
        {
          if (value != _String1)
          {
            _String1 = value;
            NotifyPropertyChanged("String1");
          }
        }
      }
    
      public string ColorHex
      {
        get
        {
          return _ColorHex;
        }
        set
        {
          if (value != _ColorHex)
          {
            _ColorHex = value;
            NotifyPropertyChanged("ColorHex");
          }
        }
      }
    
      private void NotifyPropertyChanged(string info)
      {
        if (PropertyChanged != null)
        {
          PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    }
