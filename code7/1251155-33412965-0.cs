    class Program
    {
        static void Main(string[] args)
        {
            List<object> foo = new List<object>();
            List<Person> bar = new List<Person>();
            List<object> some = (List<object>) bar;
        }
        class Person { }
    }
