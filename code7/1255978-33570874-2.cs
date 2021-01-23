    class DataBuilder
    {
        public Dictionary<string, List<string>> Data { get; } = new Dictionary<string, List<string>>();
        public void Add(string key, string dataVal)
        {
            if (!Data.ContainsKey(key))
            {
                Data.Add(key, new BaseList<string>());
            }
            Data[key].Add(dataVal);
        }
    }
