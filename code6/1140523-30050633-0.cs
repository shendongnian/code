    class MyCustomConverter : JsonConverter
    {
        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            var jobj = JObject.Load(reader);
            var model = new ModelError();
            var array = (JArray) jobj["property"];
            foreach(var item in array)
            {
                switch(item["-key"].ToString())
                {
                    case "Message":
                        // Should checking if item["#value"] null
                        model.Message = item["#value"].ToString();
                        break;
                    case etc://write your code
                }
            }
            return model;
        }
    }
    
    [JsonConverter(typeof(MyCustomConverter))]
    Class ModelError
    {
       string Message;
       Exception InnerException;
       string TargetSite;
       string StackTrace;
       string HelpLink;
       string Source;
       string HResult;
    }
    class Container
    {
        public ModelError ModelError {get;set;}
    } 
    var modelError = JsonConvert.DeserializeObject<Container>(json);
