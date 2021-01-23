    private ObservableCollection<Person> persons;
    public ObservableCollection<Person> Persons
    {
       get { return persons; }
       set
       {
          persons = value;
          OnPropertyChanged("Persons");
        }
    }        
