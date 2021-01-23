    using Newtonsoft.Json;
    using RestSharp.Deserializers;
    
    namespace IntegrationTests.Common
    {
        class NewtonsoftJsonSerializer : IDeserializer
        {
            private Newtonsoft.Json.JsonSerializer serializer;
    
            public NewtonsoftJsonSerializer(Newtonsoft.Json.JsonSerializer serializer)
            {
                this.serializer = serializer;
            }
    
            public string DateFormat { get; set; }
    
            public string Namespace { get; set; }
    
            public string RootElement { get; set; }
    
            public T Deserialize<T>(RestSharp.IRestResponse response)
            {
                var content = response.Content;
                return JsonConvert.DeserializeObject<T>(content);
            }
    
            public static NewtonsoftJsonSerializer Default
            {
                get
                {
                    return new NewtonsoftJsonSerializer(new Newtonsoft.Json.JsonSerializer()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    });
                }
            }
        }
    }
