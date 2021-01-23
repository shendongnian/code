    public class Error{
       public string error_code { get; set; }
       public string message { get; set; }
    }
    
    [JsonConverter(typeof(CustomConverter<Success>))]
    public class Success{
       public Guid Id { get; set; }
    }
    
    public class CustomConverter<T> : JsonConverter where T : new() {
       public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
       {
          JObject jObject = JObject.Load(reader);
          if (jObject.ContainsKey("error_code")) {
              return jObject.ToObject(typeof(ProvisoErrorResponse));
          }
    
          var instance = new T();
          serializer.Populate(jObject.CreateReader(), instance);
          return instance;
       }
    }
