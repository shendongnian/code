    public class PersonViewModel : INotifyPropertyChanged
    {
        public string FullName
        {
            get 
            {
                return string.Format("{0} {1}", person.FirstName, person.LastName);
            }
        }
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                    OnPropertyChanged("FullName");
                }
            }
        }
    
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                    OnPropertyChanged("FullName");
                }
            }
        }
        // remainder of the class remains the same
    }
