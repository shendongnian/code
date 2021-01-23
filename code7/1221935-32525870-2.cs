    var jsonSerializer = new JavaScriptSerializer();
    var jsonString = /*your json string*/
       
    var yourList = jsonSerializer.Deserialize<List<YourClass>>(jsonString);
    
    public class YourClass
    {
        [JsonProperty(PropertyName = "0")]
        public string Zero { get; set; }
        
        [JsonProperty(PropertyName = "1")]
        public string One { get; set; }
    }
