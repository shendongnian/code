        There is one breaking change: the default Json*Serializer* is no longer 
        compatible with Json.NET. To use Json.NET for serialization, copy the code 
        from https://github.com/restsharp/RestSharp/blob/86b31f9adf049d7fb821de8279154f41a17b36f7/RestSharp/Serializers/JsonSerializer.cs 
        and register it with your client:
        var client = new RestClient();
        client.JsonSerializer = new YourCustomSerializer();
 
    RestSharp's new built-in JSON serializer doesn't understand `JObject` so you need to follow the instructions above if you are using one of these more recent versions, Create:
	    public class JsonDotNetSerializer : ISerializer
	    {
	        private readonly Newtonsoft.Json.JsonSerializer _serializer;
            
            /// <summary>
		    /// Default serializer
		    /// </summary>
		    public JsonDotNetSerializer() {
			    ContentType = "application/json";
                _serializer = new Newtonsoft.Json.JsonSerializer {
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Include,
                    DefaultValueHandling = DefaultValueHandling.Include
                };
		    }
            /// <summary>
            /// Default serializer with overload for allowing custom Json.NET settings
            /// </summary>
            public JsonDotNetSerializer(Newtonsoft.Json.JsonSerializer serializer){
                ContentType = "application/json";
                _serializer = serializer;
            }
		    /// <summary>
		    /// Serialize the object as JSON
		    /// </summary>
		    /// <param name="obj">Object to serialize</param>
		    /// <returns>JSON as String</returns>
		    public string Serialize(object obj) {
			    using (var stringWriter = new StringWriter()) {
				    using (var jsonTextWriter = new JsonTextWriter(stringWriter)) {
					    jsonTextWriter.Formatting = Formatting.Indented;
					    jsonTextWriter.QuoteChar = '"';
					    _serializer.Serialize(jsonTextWriter, obj);
					    var result = stringWriter.ToString();
					    return result;
				    }
			    }
		    }
		    /// <summary>
		    /// Unused for JSON Serialization
		    /// </summary>
		    public string DateFormat { get; set; }
		    /// <summary>
		    /// Unused for JSON Serialization
		    /// </summary>
		    public string RootElement { get; set; }
		    /// <summary>
		    /// Unused for JSON Serialization
		    /// </summary>
		    public string Namespace { get; set; }
		    /// <summary>
		    /// Content type for serialized content
		    /// </summary>
		    public string ContentType { get; set; }
	    }
    And then do:
            RestRequest req = new RestRequest(@"apicall/smsmessaging/v2/outbound/3313/requests", Method.POST);
            req.JsonSerializer = new JsonDotNetSerializer();
