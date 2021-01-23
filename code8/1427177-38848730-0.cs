    class Example
    {
        private ImmutableList<string> _list = ImmutableList<string>.Empty;
        private readonly object _lock = new object();
    
        public IReadOnlyList<string> Contents => _list;
    
        public void ModifyOperation(string example)
        {
            lock (_lock)
            {
                // ...
                _list = _list.Add(example);
                // ...
            }
        }
    }
