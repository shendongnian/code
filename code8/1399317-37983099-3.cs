    var test = new PartnerLoginOptions
            {
                ReturnDeviceType = true,
                ReturnUpdatePromptVersions = false
            };
            var json = JsonConvert.SerializeObject(test, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[] {new OptionalBoolConverter()}
            });
