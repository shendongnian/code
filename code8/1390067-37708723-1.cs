    class ArrayToDictionaryConverter : JsonConverter
    {
        private string[] keysArray;
        public ArrayToDictionaryConverter(Type containingObjectType, string keysArrayFieldName)
        {
            FieldInfo field = containingObjectType.GetField(keysArrayFieldName);
            if (field == null)
                throw new Exception("Could not find " + keysArrayFieldName + " field on type " + containingObjectType.Name + ".");
            if (!field.Attributes.HasFlag(FieldAttributes.Static) || field.FieldType != typeof(String[]))
                throw new Exception("The " + keysArrayFieldName + " field on " + containingObjectType.Name + " must be declared as static string[].");
            keysArray = (string[])field.GetValue(null);
        }
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Dictionary<string, object>));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            Dictionary<string, object> dict = new Dictionary<string, object>();
            for (int i = 0; i < array.Count; i++)
            {
                string key = i < keysArray.Length ? keysArray[i] : "key" + i;
                dict.Add(key, (string)array[i]);
            }
            return dict;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
