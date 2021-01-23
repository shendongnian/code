    public class Response
    {
    	[JsonProperty("status")]
        public string Status { get; set; }
    	[JsonProperty("data")]
        public dynamic Data { get; set; }
    }
    
    
    var response = JsonConvert.DeserializeJson<Response>(json);
    .
    .
    .
    
    Type responseDataType = response.Data.GetType();
    
    if(responseDataType.IsArray) {
    	// It's an array, what to do?
    }
    else {
    	// Not an array, what's next?
    }
