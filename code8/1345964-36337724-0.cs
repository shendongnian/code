    class BaseClass
    {
        private readonly Dictionary<string, string> properties = new Dictionary<string, string>();
        protected string this[string key]
        {
            get { string value; return properties.TryGetValue(key, out value) ? value : null; }
            set { if (value == null) properties.Remove(key); else properties[key] = value; }
        }
    
        public BaseClass()
        {
            this["p1"] = "v1";
            this["p2"] = "v2";
        }
    
        public override string ToString()
        {
            return GetType().Name + ".Properties: " + string.Join(",", properties.Select(kvp => $"{kvp.Key}:{kvp.Value}"));
        }
    }
    
    class DerivedClass : BaseClass
    {
        public DerivedClass() : base()
        {
            this["p2"] = "update";
            this["p3"] = "v3";
        }
    }
