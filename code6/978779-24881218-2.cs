    public sealed class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver();
            Converters.Add(new StringEnumConverter
            {
                AllowIntegerValues = false, 
                CamelCaseText = true
            });
            Formatting = Formatting.Indented;
        }
    }
