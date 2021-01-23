    public class Character : INotifyPropertyChanged
    {
        private int age = 20;
        public int Age
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    age = value;
                    NotifyPropertyChanged("Age");
                }
            }
        }
        private string name = "Default Name";
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        private ObservableCollection<Spells> spells = new ObservableCollection<Spells>();
        public ObservableCollection<Spells> Spells
        {
            get { return spells; }
            set
            {
                if (spells != value)
                {
                    spells = value;
                    NotifyPropertyChanged("Spells");
                }
            }
        }
        ...
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
