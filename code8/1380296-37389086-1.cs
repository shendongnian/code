    class Program
    {
      static void Main(string[] args)
      {
        List<Person> peopleList1 = new List<Person>();
        peopleList1.Add(new Person() { ID = 1 });
        peopleList1.Add(new Person() { ID = 2 });
        peopleList1.Add(new Person() { ID = 3 });
        peopleList1.Add(new Person() { ID = 4});
        peopleList1.Add(new Person() { ID = 5});
    
        List<Person> peopleList2 = new List<Person>();
        peopleList2.Add(new Person() { ID = 1 });
        peopleList2.Add(new Person() { ID = 4});
    
        var result = peopleList1.Intersect(peopleList2);
      }
    }
