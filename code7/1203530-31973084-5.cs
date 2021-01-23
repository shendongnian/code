    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
    
            personList.Add(new Person { Name = "Ahmad", LastName = "Ashfaq", Age = 20 });
            personList.Add(new Person { Name = "Ali", LastName = "Murtza", Age = 23 });
            personList.Print();
        }
    }
