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
        protected IPerson Parent { get; set; }
        public string ParentName { get { return this.Parent != null ? this.Parent.Name : String.empty; } }
        public Person(IPerson parent = null)
        {
            this.Parent = parent;
        }
    }
