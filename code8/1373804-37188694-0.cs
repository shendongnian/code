    class Person
    {
        public string name { get; private set; }
        public int age { get; private set; }
        public Person parent { get; private set; }
        public bool child { get; private set; }
        public Person(string name, int age, Person parent, bool child)
        {
            this.name = name;
            this.age = age;
            this.parent = parent;
            this.child = child;
        }
    }
