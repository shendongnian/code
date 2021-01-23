     class ViewModel : INotifyPropertyChanged
     {
         public int X
         {
             get { return _x; }
             set 
             {
                 _x = value;
                 _xSquared = _a * _a;
                 NotifyPropertyChanged("X");
                 NotifyPropertyChanged("XSquared");
             }
         }
         public int XSquared { get { return _xSquared; }
     }
