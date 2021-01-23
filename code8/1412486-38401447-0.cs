      public class Envelope: ModelBase 
        {
            private string _name;
    
            public string Name
            {
                get { return _name; }
                set { _name= value; OnPropertyChanged("Name"); }
            }
    
        }
    
        public class ModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void OnPropertyChanged(string propName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
    
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propName));
                }
            }
        }
