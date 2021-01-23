    public class myClass: INotifyPropertyChanged
    {
        private string _myStringOne;
        public string myStringOne { 
           get { return _myStringOne; } 
           set 
           {
               if(_myStringOne != value)
                {
                      _myStringOne = value;
                      NotifyPropertyChanged("myStringOne");
                }
          }
       }
    
       public event PropertyChangedEventHandler PropertyChanged;
    
       public void NotifyPropertyChanged(string propName)
       {
            if(this.PropertyChanged != null)
                 this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
       }
    }
