    // ReSharper disable CheckNamespace
    namespace RestSharp.Deserializers
    // ReSharper restore CheckNamespace
    {
        public class DynamicJsonDeserializer : IDeserializer
        {
            public string RootElement { get; set; }
            public string Namespace { get; set; }
            public string DateFormat { get; set; }
     
            public T Deserialize<T>(RestResponse response) where T : new()
            {
                return JsonConvert.DeserializeObject<dynamic>(response.Content);
            }
        }
    }
