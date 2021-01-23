    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""12345"": ""text string"",
                ""rel"": ""myResource""
            }";
            var settings = new DataContractJsonSerializerSettings();
            settings.DataContractSurrogate = new MyDataContractSurrogate();
            settings.KnownTypes = new List<Type> { typeof(Dictionary<string, object>) };
            settings.UseSimpleDictionaryFormat = true;
            MyResource mr = Deserialize<MyResource>(json, settings);
            Console.WriteLine("Special name: " + mr.SpecialName);
            Console.WriteLine("Special value: " + mr.SpecialValue);
            Console.WriteLine("Rel: " + mr.Rel);
            Console.WriteLine();
            json = Serialize(mr, settings);
            Console.WriteLine(json);
        }
        public static T Deserialize<T>(string json, DataContractJsonSerializerSettings settings = null)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                if (settings == null) settings = GetDefaultSerializerSettings();
                var ser = new DataContractJsonSerializer(typeof(T), settings);
                return (T)ser.ReadObject(ms);
            }
        }
        public static string Serialize(object obj, DataContractJsonSerializerSettings settings = null)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                if (settings == null) settings = GetDefaultSerializerSettings();
                var ser = new DataContractJsonSerializer(obj.GetType(), settings);
                ser.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
