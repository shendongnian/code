    private ObservableCollection<Person> persons;
    public ObservableCollection<Person> Persons
    {
        get { return persons; }
        set { persons = value;
             OnPropertyChanged("Persons");
        }
    }
    private void FillData()
    {
       persons = new ObservableCollection<Person>();
       for (int i = 0; i < 30; i++)
       {
          if(i%2==0)
             persons.Add(new Person() { IdPerson=i, Name="", SurName="Albahari"});
          else
              persons.Add(new Person() { IdPerson = i, Name = "Ben & Joseph " + i.ToString(), SurName = "Albahari" });
       }
       //If you want set some value, you can do it:
       if(persons[0].Name=="")
          persons[0].Name = "That should be Name";
