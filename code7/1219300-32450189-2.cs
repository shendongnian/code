    public class Person
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Street { get; set; }
    }
     List<Person> personList = new List<Person>();
     personList.Add(new Person()
     {
          Name = "Sample",
          SecondName = "S",
          Street = "4825235186"
     });
