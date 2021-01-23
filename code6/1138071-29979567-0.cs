    public class Base : INotifyPropertyChanged
    {
       private string _name;
       public string Name { get
       {
           return _name;
       }
       set{
           if(PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs("Some arg"));
           _name = value;
       }
    }
    
       public event PropertyChangedEventHandler PropertyChanged;
    }
