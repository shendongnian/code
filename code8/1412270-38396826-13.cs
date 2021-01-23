        public class ChildViewModel : ViewModelBase
        {
            private string _childName;
    
            public string ChildName
            {
                get { return _childName; }
                set 
                { 
                  _childName = value; 
                  OnPropertyChanged("ChildName"); 
                }
            }
    
        }
