    /// <summary>
    /// Specialized collection that associates multiple keys with a single item.
    /// 
    /// WARNING: Not production quality because it does not react well to dupliate or missing keys.
    /// </summary>
    public class RequestTraceCollection
    {
        /// <summary>
        /// Internal dictionary for doing lookups.
        /// </summary>
        private readonly Dictionary<string, RequestTrace> _dictionary = new Dictionary<string, RequestTrace>();
        /// <summary>
        /// Retrieve an item by <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Any of the keys associated with an item</param>
        public RequestTrace this[string key]
        {
            get { return _dictionary[key]; }
        }
        /// <summary>
        /// Add an <paramref name="item"/> to the collection.  The item must
        /// have at least one string in the Id array.
        /// </summary>
        /// <param name="item">A RequestTrace object.</param>
        public void Add(RequestTrace item)
        {
            _dictionary.Add(item.Id.Peek(), item);
        }
        /// <summary>
        /// Given an <paramref name="item"/> in the collection, add another key
        /// that it can be looked up by.
        /// </summary>
        /// <param name="item">Item that exists in the collection</param>
        /// <param name="key">New key alias</param>
        public void AddAliasKey(RequestTrace item, string key)
        {
            item.Id.Push(key);
            _dictionary.Add(key, item);
        }
        /// <summary>
        /// Remove an <paramref name="item"/> from the collection along with any
        /// of its key aliases.
        /// </summary>
        /// <param name="item">Item to be removed</param>
        public void Remove(RequestTrace item)
        {
            while (item.Id.Count > 0)
            {
                var key = item.Id.Pop();
                _dictionary.Remove(key);
            }
        }
    }
