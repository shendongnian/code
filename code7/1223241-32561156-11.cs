    class DictionaryCopier : IHeterogeneousDictionaryKeyVisitor
    {
        readonly HeterogeneousDictionary _source;
        readonly HeterogeneousDictionary _destination;
        public DictionaryCopier(HeterogeneousDictionary source, HeterogeneousDictionary destination)
        {
            _source = source;
            _destination = destination;
        }
        public void PerformCopy()
        {
            foreach (var key in _source.Keys)
            {
                // See you soon.
                key.Accept(this);
            }
        }
        /// <summary>
        /// We fall back here with a typed key.
        /// </summary>
        public void Visit<TValue>(HeterogeneousDictionaryKey<TValue> key)
        {
            // Here the value is typed.
            var value = _source.Get(key);
            _destination.Add(key, value);
        }
    }
