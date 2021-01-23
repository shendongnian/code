    struct ValuePair
    {
        public string Name  { get; set; }
        public string Id { get; set; }        
        public ValuePair(string name, string id) : this()
        {
            Name = name;
            Id = id;
        }
        public override string ToString()
        {
            return "Name : " + Name + ", Id : " + Id;
        }
    }
