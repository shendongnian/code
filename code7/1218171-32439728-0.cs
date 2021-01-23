    public class Profile : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }
        private string surname = string.Empty;
        public string Surname
        {
            get { return surname; }
            set { surname = value; NotifyPropertyChanged("Surname"); }
        }
        private string fullName = string.Empty;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; NotifyPropertyChanged("FullName"); }
        }
    }
