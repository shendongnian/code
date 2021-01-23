    public Person : DomainEntity<Guid>
    {
        //..
        public Person(string name)
          : base(Guid.New()) // Providing a unique GUID
        {
            Name = name;
        }
    }
