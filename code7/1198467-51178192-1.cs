    public struct MyDictionaryBuilder<TKey, TValue> : IEnumerable
    {
        private ImmutableDictionary<TKey, TValue>.Builder _builder;
    
        public MyDictionaryBuilder(int dummy)
        {
            _builder = ImmutableDictionary.CreateBuilder<TKey, TValue>();
        }
    
        public void Add(TKey key, TValue value) => _builder.Add(key, value);
    
        public TValue this[TKey key]
        {
            set { _builder[key] = value; }
        }
        public ImmutableDictionary<TKey, TValue> ToImmutable() => _builder.ToImmutable();
    
        public IEnumerator GetEnumerator()
        {
            // Only implementing IEnumerable because collection initializer
            // syntax is unavailable if you don't.
        throw new NotImplementedException();
        }
    }
