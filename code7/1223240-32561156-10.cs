    class HeterogeneousDictionary
    {
        ...
        public Dictionary<HeterogeneousDictionaryKeyBase, object>.KeyCollection Keys
        {
            get { return _dictionary.Keys; }
        }
        ...
    }
