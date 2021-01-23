    //class for key value type data
    class DeserializedData
    {
        List<KeyValuePair<string, string>> NewData = 
        new List<KeyValuePair<string, string>>();
        internal void Add(KeyValuePair<string, string> row)
        {
            NewData.Add(row);
        }
    }
    [DataContract]
    class ObjectDataList
    {
        [DataMember(Name ="data")]
        List<object> Data { get; set; }
        public IEnumerator<object> GetEnumerator()
        {
            foreach (var d in Data)
            {
                yield return d;
            }
        }
    }
