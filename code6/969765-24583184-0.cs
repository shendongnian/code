    public class Person : INotifyPropertyChanged
    {
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Person))
            {
                return false;
            }
            Person p = (Person)obj;
            return (Name == null && p.Name == null) || (Name != null && Name.Equals(p.Name));
        }
        public override int GetHashCode()
        {
            return Name == null ? 0 : Name.GetHashCode();
        }
        public Person(string name)
        {
            Name = name;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
