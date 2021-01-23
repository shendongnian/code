    class GuidList // You can implement IReadOnlyList
    {
        public bool Dirty { get; private set;}
        // Omit if implementing `IReadOnlyList`
        public Guid[] Guids { get { return guidCollection.ToArray() }
        public void Add(Guid guid) // Do similarly for remove
        {
            Dirty = true;
            // implement logic
        }
    }
