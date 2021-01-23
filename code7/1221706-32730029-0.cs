    using System;
    namespace TestCon
    {
        class Program
        {
            public static void Main()
        {
            Person person = null;
            //Person person = new Person() { Name = "Jack" };
            //Using an "if" null check.
            if (person != null)
            {
                Console.WriteLine(person.Name);
                person.Name = "Jane";
                Console.WriteLine(person.Name);
            }
            //using a ternary null check.
            string arg = (person != null) ? person.Name = "John" : arg = null;
            //Remember the first statment after the "?" is what happens when true. False after the ":". (Just saying "john" is not enough)
            //Console.WriteLine(person.Name);
            if (arg == null)
            {
                Console.WriteLine("arg is null");
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    public class Person
    {
        public string Name { get; set; }
    }
}
