    public class MyClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string firstName { get; set; }
        private string lastName { get; set; }
        public string FirstName
        {
            get 
            {
                return firstName;
            }
            set
            {
                firstName = value;
                PropertyChangedEvent("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                PropertyChangedEvent("LastName");
            }
        }
        private void PropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
