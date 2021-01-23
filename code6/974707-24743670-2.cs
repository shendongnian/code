    [DataContract]
    class ExampleSaveableClass
    {
        [DataMember]
        public List<ExampleElements> _elements;
        
        public ExampleSaveableClass()
        {
            _elements = new List<ExampleElements>();
        }
        internal static ExampleSaveableClass FromJsonString(string jsonString)
        {
            ExampleSaveableClass loadedSavableClass = Deserialize<ExampleSaveableClass>(jsonString);
            return loadedSavableClass;
        }
        private static T Deserialize<T>(string json)
        {
            var instance = Activator.CreateInstance<T>();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(instance.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }
        internal string ToJsonString()
        {
            DataContractJsonSerializer ser =
                new DataContractJsonSerializer(typeof(ExampleSaveableClass));
            using (MemoryStream ms = new MemoryStream())
            {
                ser.WriteObject(ms, this);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
