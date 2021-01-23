    public class Profile : INotifyPropertyChanged
    {
        public string name;
        public string surname;
        public string fullname;
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public string Surname { get { return surname; } set { surname = value; OnPropertyChanged("Surname"); } }
        public string FullName { get { return fullname; } set { fullname = value; OnPropertyChanged("Fullname"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
