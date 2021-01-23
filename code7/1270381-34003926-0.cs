    class Person
    {
        private readonly string _name;
        // Old school: public string Name { get { return _name; } }
        public string Name => _name; 
        public Person(string name)
        {
            _name = name;
        }
    }
