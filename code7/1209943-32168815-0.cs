    public class RestSharpJsonNetDeserializer : IDeserializer
    {
        public RestSharpJsonNetDeserializer()
        {
            ContentType = "application/json";
        }
        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
        public string DateFormat { get; set; }
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string ContentType { get; set; }
    }
