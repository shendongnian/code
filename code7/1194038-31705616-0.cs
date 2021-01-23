    public struct Person
    {
        public string Name { get; }
        public int Age { get; }
        public Person(string name = "Bob", int age = 42)
        {
            Name = name;
            Age = age;
        }
    }
