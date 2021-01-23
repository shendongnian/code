    public sealed class ActionModelConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ActionModel).IsAssignableFrom(objectType);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            ActionModel actionModel = new ActionModel();
    
            // TODO: Manually populate properties
            actionModel.Id = (string)jObject["id"].ToObject<string>();
    
            var type = (ActionModel.Type)jObject["type"].ToObject<ActionModel.Type>();
            switch (type)
            {
              case ActionModel.Type.Open:
                var actionResult = jObject["result"].ToObject<ActionOpenResult>(jsonSerializer);
    
              default:
                throw new JsonSerializationException($"Unsupported action type: '{type}'");
            }
    
            actionModel.Result = actionResult;
    
            return actionModel;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
