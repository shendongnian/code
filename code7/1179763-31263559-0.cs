    public class Test
    {
        private List<Dictionary<string, object>> _list = new List<Dictionary<string, object>>();
        public IEnumerable<IReadOnlyDictionary<string, object>> Items
        {
            get
            {
                foreach (var item in _list)
                    yield return item;
            }
        }
        public IReadOnlyDictionary<string, object> this[int i]
        {
            get { return _list[i]; }
        }
        public int Count
        {
            get { return _list.Count; }
        }
    }
