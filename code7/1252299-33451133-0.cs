    class Person
    {
        public string Name{ get; set; }               // the property we need for binding
        public Person(string name) { Name = name; }   // a constructor for convenience
        public override string ToString() {  return Name; }  // necessary to show in ListBox
    }
    class Repository
    {
        public List<Person> persons { get; set; }
        public Repository()  { persons = new List<Person>(); }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        Repository rep = new Repository();           // set up the repository
        rep.persons.Add(new Person("Tom Jones"));    // add a value
        listBox1.DataSource = rep.persons;           // bind to a List<T>
        listBox1.DisplayMember = Name;               // determine the binding field
    }
