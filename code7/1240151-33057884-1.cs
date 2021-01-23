    public class Person
    {
        public string Name { get; set; }
    }
    public class Spy : Person
    {
        public new string Name
        {
            get { throw new InvalidOperationException(); }
        }
    }
