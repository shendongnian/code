    public class Derived : Base
    {
      private string _derivedName;
    
      public string DerivedName { 
        get { return _derivedName; }
        set
        { 
          _derivedName = value;
          RaisePropertyChanged("DerivedName");
        }
      }
      protected virtual void RaisePropertyChanged(string propertyName)
      {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
          handler(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    }
