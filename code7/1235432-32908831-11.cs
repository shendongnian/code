        static private string SerializeMyObject(object myObject)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCaseIgnoringPropertyJsonResolver<JsonIgnoreSerializeAttribute>()
            };
            var json = JsonConvert.SerializeObject(myObject, settings);
            return json;
        }
