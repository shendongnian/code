    class Category<T>
    {
        public Category(string name, Predicate<T> predicate)
        {
            Name = name;
            Predicate = predicate;
        }
        public string Name { get; }
        public Predicate<T> Predicate { get; }
    }
