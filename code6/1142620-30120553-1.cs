    public Person : DomainEntity<int>
    {
        //..
        public Person(int identity, string name)
          : base(identity) // Providing a unique GUID
        {
            Name = name;
        }
    }
