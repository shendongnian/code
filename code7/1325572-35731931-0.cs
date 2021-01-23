    public sealed class Database
    {
        private readonly List<List<Entry>> _list = new List<List<Entry>>();
        public Database()
        {
            // Create your list of lists.
            List<Entry> innerList = new List<Entry>
            {
                new Entry {Value = 1},
                new Entry {Value = 2}
            };
            _list.Add(innerList);
        }
        public IReadOnlyCollection<IReadOnlyCollection<IEntry>> Data => _list;
    }
