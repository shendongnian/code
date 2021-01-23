    class Person
    {
       public static List<Person> selectedPersons;
       Person person;
       public Person(Person _nestedPerson)
       {
           if(selectedPersons == null)
             selectedPersons = new List<Person>();
           person = _nestedPerson;
       }
       public bool IsSelectedPerson { get; set; }
       public string Name { get; set; }
       public void Visit()
       {
           if(this.IsSelectedPerson)
             selectedPersons.Add(this);
           if(this.person != null)
             this.person.Visit();
       }
    }
