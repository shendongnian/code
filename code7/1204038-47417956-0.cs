    public class Person
        {
            public int Id {get; set;}
            public DateTime DoB {get;set;}
            public String Name {get;set;}
        }
    
    public class MyResolver
    {
        public Func<Person, string> Resolve {get;set;}
        public string ResolveToString<T>(T r) where T : Person
        {
            return this.Resolve(r);
        }
    }
    
    // code to use here...
    var employee = new Person();
    employee.Id = 1234;
    employee.Name = "John";
    employee.DoB = new DateTime(1977,1,1);
    
    var resolver = new MyResolver();
    resolver.Resolve = x => $"This person is called {x.Name}, DoB is {x.DoB.ToString()} and their Id is {x.Id}";
    
    Console.WriteLine(resolver.ResolveToString(employee));
