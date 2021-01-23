    public class Program
    {
        static void Main(string[] args)
        {
            var x = new Person("Old name");
            var y = x;
            M(ref x);
            Console.WriteLine(y.Name); // Prints "Old name"
            Console.ReadKey();
        }
        static void M(ref Person person)
        {
            person = new Person("New name");
        }
    }
    class Person
    {
        public string Name { get; }
        public Person(string name)
        {
            Name = name;
        }
    }
    
