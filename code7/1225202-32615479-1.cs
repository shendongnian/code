    public class Container {
        private readonly IList<Item> _items;
        private readonly synclock = new object();
        public Container() {
            _items = new List<Item>();
        }
        public IReadOnlyList<Item> Items {
            get {
                lock (synclock) {
                    return _items.ToList().AsReadOnly();
                }
            }
        }
        public void Add(Item item) {
            lock (synclock) {
                _items.Add(item);
            }
        }
    }
