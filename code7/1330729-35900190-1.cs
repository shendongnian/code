            var settings = new JsonSerializerSettings 
            {
                 NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = ExtensionNameMappingContractResolver.RemoveNonAlphanumericCharactersInstance 
            };
            var serializer = JsonSerializer.CreateDefault(settings);
