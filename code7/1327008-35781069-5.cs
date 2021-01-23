                var serializerSettings = new JsonSerializerSettings()
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateParseHandling = Newtonsoft.Json.DateParseHandling.DateTimeOffset,
                    ContractResolver = DataContractForCollectionsResolver.Instance
                };
