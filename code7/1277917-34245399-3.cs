    public class MyData:INotifyPropertyChanged
    {
        //public string FirstName { get; set; }
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value;
            OnPropertyChanged("FirstName");
            }
        }
        private string surName;
        public string Surname
        {
            get { return surName; }
            set { surName = value;
            OnPropertyChanged("Surname");
            }
        }
        
        //public string Surname { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
