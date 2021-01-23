    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Name= "SomeOne"; Age=16; };
            Console.WriteLine(person.Age);
            Console.WriteLine(person.FamileName == null);
        }
    }
