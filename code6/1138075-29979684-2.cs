    public class Derived : Base, INotifyPropertyChanged
    {
    
      public string DerivedName { 
        get { return Name; }
        set
        { 
          Name = value;
          RaisePropertyChanged("DerivedName");
          RaisePropertyChanged("Name"); //probably you will not need this line
        }
      }
    }
 
