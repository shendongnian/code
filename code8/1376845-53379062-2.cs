    public class ResourceRecordConverter : CustomCreationConverter<ResourceRecord>
    {
        private ResourceRecordTypeEnum _currentObjectType;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jobj = JObject.ReadFrom(reader);
            // jobj is the serialized json of the reuquest
            // It pulls from each record the "type" field as it is in requested json,
            // in order to identify which object to create in "Create" method
            _currentObjectType = jobj["type"].ToObject<ResourceRecordTypeEnum>();
            return base.ReadJson(jobj.CreateReader(), objectType, existingValue, serializer);
        }
        public override ResourceRecord Create(Type objectType)
        {
            switch (_currentObjectType)
            {
                case ResourceRecordTypeEnum.a:
                    return new ARecord();
                case ResourceRecordTypeEnum.b:
                    return new BRecord();
                default:
                    throw new NotImplementedException();
            }
        }
    }
