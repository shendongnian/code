        static private string SerializeMyObject(TrackExtended myObject)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCaseIgnoringPropertyJsonResolver<JsonIgnoreSerializeAttribute>()
            };
            var json = JsonConvert.SerializeObject(myObject, settings);
            return json;
        }
