    public class Service1 : IService1
    {
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "{type}")]
        public Stream GetDataUsingDataContract(string type)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii };
            string json = JsonConvert.SerializeObject(new CompositeType { StringValue = "Hello Иван" }, settings);
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return new MemoryStream(Encoding.UTF8.GetBytes(json));
        }
    }
