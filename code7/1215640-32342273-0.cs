    class Parent
    {
        public Parent()
        {
            Child = new Child();
        }
        public Child Child { get; private set; }
    }
    class Child
    {
        public Child()
        {
            Strings = new List<string>();
        }
        public List<string> Strings { get; private set; }
    }
    static class Program
    {
        static void Main()
        {
            // works fine now
            var parent = new Parent
            {
                Child =
                {
                    Strings = { "hello", "world" }
                }
            };
        }
    }
