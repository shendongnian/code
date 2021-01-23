    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Person { Name = "Alberto Monteiro", Age = 25 };
            p.Save("person.bin");
            var person = Person.ReadFromFile("person.bin");
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
