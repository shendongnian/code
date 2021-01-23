    public class Person:INotifyPropertyChanged
    {
        public int IdPerson { get; set; }
        
        private string name;
        public string Name
        {
            get { return name; }
            set {
                name =value;
                OnPropertyChanged("Name");
            }
        }
        private string surname;
        public string SurName
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("SurName");
            }
        }        
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
