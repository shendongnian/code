    public sealed class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {    
            ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
