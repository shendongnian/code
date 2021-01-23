    class GuidList
    {
        public bool Dirty { get; private set;}
        public void Add(Guid guid) // Do similarly for remove
        {
            Dirty = true;
            // implement logic
        }
    }
