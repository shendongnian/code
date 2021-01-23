csharp
    public class Response
    {
        public string Status;
        public string ErrorCode;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage;
    }
    var response = JsonConvert.DeserializeObject<Response>(data);
The benefit of this is to isolate the data definition (what) and deserialization (use), the deserilazation needn’t to care about the data property, so that two persons can work together, and the deserialize statement will be clean and simple. 
