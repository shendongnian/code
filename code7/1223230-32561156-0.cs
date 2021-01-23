    /// <summary>
    /// Base class for all dictionary key.
    /// 
    /// <remarks>The key name is REALLY usefull for debug purpose.</remarks>
    /// </summary>
    abstract class HeterogeneousDictionaryKeyBase
    {
        readonly string _name;
        protected HeterogeneousDictionaryKeyBase(string name)
        {
            _name = name;
        }
        public override string ToString()
        {
            return _name;
        }
    }
    sealed class HeterogeneousDictionaryKey<TValue> : HeterogeneousDictionaryKeyBase
    {
        public HeterogeneousDictionaryKey(string name)
            : base(name)
        {
        }
    }
