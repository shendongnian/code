    public static class ConverterSettings
    {
        public static JsonSerializer GetSerializer()
        {
            return JsonSerializer.Create(new JsonSerializerSettings()
            {
                ContractResolver = new ConditionalCamelCaseContractResolver()
            });
        }
    }
