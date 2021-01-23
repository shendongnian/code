    string someJsonString = "{ ... }";
    MimeMessage deserialized = JsonConvert.DeserializeObject<MimeMessage>(
        someJsonString, new JsonSerializerSettings
        { 
            ContractResolver = new MimeMessageContractResolver(),
            Converters = new JsonConverter[] 
            { 
                new MimeHeaderConverter()
            }
        });
