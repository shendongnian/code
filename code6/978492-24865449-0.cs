    class Parent
    {
        public string Name { get; set; }
        private readonly List<Child> _children = new List<Child>();
        public List<Child> Children
        {
            get { return _children; }
        }
    }
    class Child
    {
        public string Name { get; set; }
    }
