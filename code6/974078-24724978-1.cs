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
    
                _girstName = value;
                
                //Use a reuseable function to "raise" your event so it makes 
                // multiple properties easier. The standard name for this raising
                // function is OnXxxxxxx where Xxxxxxx is your Event name and should
                // be private or protected.
                OnPropertyChanged("FirstName")
            }
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
    
        private OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(
                    this, new PropertyChangedEventArgs(propertyName));
        }
    }
