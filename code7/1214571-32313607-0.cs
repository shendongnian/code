    interface IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; }
    }
    class Person : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IPerson Parent { get; set; }
        public string ParentName { get { return parent != null ? parent.Name : String.empty; } }
    }
