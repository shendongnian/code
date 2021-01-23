    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;    
       
        private String _firstName;
        private String _age;
    
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                //If the value did not change we shouldn't trigger the event.
                if(Object.Equals(_firstName, value))
                    return;
    
                _firstName = value;
                
                //Use a reuseable function to "raise" your event so it makes 
                // multiple properties easier. The standard name for this raising
                // function is OnXxxxxxx where Xxxxxxx is your Event name and should
                // be private or protected.
                OnPropertyChanged("FirstName")
            }
        }
    
        private OnPropertyChanged(string propertyName)
        {
            //Storing the event in a local temporary variable prevents
            // a potential NullRefrenceException when you are working
            // in a multitreaded enviorment where the last subscriber
            // could unsubscribe between the null check and the invocation.
            var tmp = PropertyChanged;
            if (tmp != null)
                tmp(this, new PropertyChangedEventArgs(propertyName));
        }
        public int Age 
        { 
            get {return _age;} 
            set
            {
                if(Object.Equals(_age, value))
                    return;
    
                _age= value;
                OnPropertyChanged("Age")
            }
        }
    }
