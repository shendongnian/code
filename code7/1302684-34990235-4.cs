    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            FillData();
        }
        private void FillData()
        {
            persons = new ObservableCollection<Person>();
            for (int i = 0; i < 30; i++)
            {
                persons.Add(new Person() { IdPerson = i, Name = "Ben & Joseph " + i.ToString(), SurName = "Albahari" });
            }   
        }
        private ObservableCollection<Person> persons;
        public ObservableCollection<Person> Persons
        {
            get { return persons; }
            set { persons = value;
                OnPropertyChanged("Persons");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
