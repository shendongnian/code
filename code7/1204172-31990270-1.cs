    class Person : IEquatable<Person>
    {
        public readonly string Name;
        public Person(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name");
            Name = name;
        }
        public static implicit operator string(Person p)
        {
            return p.Name;
        }
        public static implicit operator Person(string name)
        {
            return new Person(name);
        }
        public bool Equals(Person other)
        {
            return Name.Equals(other.Name);
        }
    }
