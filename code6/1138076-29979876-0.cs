    public class Derived : Base, INotifyPropertyChanged
    { 
      public new string Name
      {
        get { return base.Name; }
        set { base.Name = value;
              RaisePropertyChanged("Name");
            }
      } 
    }
   
