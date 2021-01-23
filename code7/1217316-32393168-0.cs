    private class MyStrangeDictionary : Dictionary<MetaInfoValueGroupTag, List<object>>
    {
        public MyStrangeDictionary() : base(MetaInfoValueGroupTag.MetainfoComparer)
        {
        }
        public List<object> this[string key]
        {
            get
            {
                return this[new MetaInfoValueGroupTag {MetaInfo = key}];
            }
            //set
            //{
            //    Add(new MetaInfoValueGroupTag { MetaInfo = key }, value);
            //} 
        }
        public bool TryGetValue(string key, out List<object> value)
        {
            if (ContainsKey(new MetaInfoValueGroupTag {MetaInfo = key}))
            {
                value = this[key];
                return true;
            }
            value = default(List<object>);
            return false;
        }
    }
