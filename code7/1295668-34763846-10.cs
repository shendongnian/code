    public void DoubleClickMethod()
    {
       MessageBox.Show("It is a Double Click");
       /*        if(parameter!=null)
           YourClass aClass=(YourClass)parameter; 
       */
    }
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
    public MainWindowViewModel()
    {
       LoadPersons();
    }
    private void LoadPersons()
    {
       persons = new ObservableCollection<Person>();
       for (int i = 0; i < 20; i++)
       {
          Persons.Add(new Person() { IdPerson = i, Name = "Charlie " + i.ToString()});
       }
