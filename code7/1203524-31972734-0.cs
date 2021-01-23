    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
    
            personList.Add(new Person { Name = "Ahmad", LastName = "Ashfaq", Age = 20 });
            personList.Add(new Person { Name = "Ali", LastName = "Murtza", Age = 23 });
    
            foreach (Person item in personList)
            {
                Console.WriteLine(item.Name);
    Console.WriteLine(item.LastName);
    Console.WriteLine(item.Age);
            }
    
            Console.ReadKey();
        }
    }
