    abstract class AbstractClass
    {
        protected abstract List<string> MyList { get; set; } // To be implemented in a child class
        void ShowList()
        {
            foreach (string member in MyList)
            {
                Console.WriteLine(member);
            }
        }
    }
    class HelloWorld : AbstractClass
    {
        protected override List<String> MyList { get; set; } = new List<string>()
        {
            "Hello", "World"
        };
    }
