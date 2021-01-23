    public class Foo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var originalFoo = new Foo
            {
                FirstName = "Foo",
                LastName = "Bar"
            };
            NotByRef(originalFoo);
            Console.WriteLine(originalFoo);
            ByRef(ref originalFoo);
            Console.WriteLine(originalFoo);
        }
        static void NotByRef(Foo foo)
        {
            // originalFoo variable won't be replaced
            foo = new Foo
            {
                FirstName = "Foo modified not by ref",
                LastName = "Bar modified not by ref"
            };
            // At this point the foo parameter is no more referencing the originalFoo variable. 
            // Updating the foo parameter properties will no longer update the originalFoo properties
            foo.FirstName = "Foo modified not by ref";                  
        }
        static void ByRef(ref Foo foo)
        {
            // originalFoo variable will be replaced
            foo = new Foo
            {
                FirstName = "Foo modified by ref",
                LastName = "Bar modified by ref"
            };           
        }
    }
