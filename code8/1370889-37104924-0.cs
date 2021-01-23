    class Contact // Immutable class
    {
        // Read-only properties. 
        public string Name { get; }
        public string Address { get; }
        public Contact(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }
    }
