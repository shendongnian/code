    [Foreachable]
    {
        public [Enumerator] GetEnumerator();
    }
    
    [Enumerator]
    {
        public bool MoveMext();
        public [ItemType] Current { get; }
    }
