    public class Container
    {
        private ImmutableList<Item> _items = ImmutableList<Item>.Empty;
        public IReadOnlyList<Item> Items { get { return _items; } }
        public void Add(Item item) { _items = _items.Add(item); }
    }
