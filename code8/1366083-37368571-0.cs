    public class SomeController : ApiController
    {
        public object Get()
        {
              SetSerializerSettings();
              Do your logic....
        }
        private void SetSerializerSettings()
        {
              this.Configuration.Formatters.JsonFormatter.SerializerSettings = 
                  new JsonSerializerSettings
                  {
                     Converters = { new StringEnumConverter { CamelCaseText = true }, },
                     ContractResolver = 
                           new CamelCasePropertyNamesContractResolver { IgnoreSerializableAttribute = true },
                     DefaultValueHandling = DefaultValueHandling.Ignore,
                     NullValueHandling = NullValueHandling.Ignore,
                     Formatting = Formatting.Indented
                  };
        }
    }
