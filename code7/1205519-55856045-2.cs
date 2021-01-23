    class Person
    {
        public long Id { get;set; }
        public string Name { get;set; }
        private List<Person> _parents = new List<Person>();
        public IReadOnlyCollection<Person> Parents => _parents.AsReadOnly();
        public void AddParent(Parent parent){
            _parents.Add(parent); 
        }
    }
