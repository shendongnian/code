    private ObservableCollection<Person> persons=new ObservableCollection<Person>();
    public ObservableCollection<Person> Persons
    {
      get { return persons; }
      set { persons = value;
            persons = new ObservableCollection<Person>(persons.OrderBy(x => x.Name));
            OnPropertyChanged("Persons");
          }
