    class MyObject
    {
        public DataDictionary MyObjectData { get; set; }
        public bool ShouldSerializeMyObjectData() { return MyObjectData != null && MyObjectData.Count > 0; }
    }
