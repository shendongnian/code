    class ListCompactionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // We only want to convert lists of non-enumerable class types (including string)
            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type itemType = objectType.GetGenericArguments().Single();
                if (itemType.IsClass && !typeof(IEnumerable).IsAssignableFrom(itemType))
                {
                    return true;
                }
            }
            return false;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JArray array = new JArray();
            IList list = (IList)value;
            if (list.Count > 0)
            {
                JArray keys = new JArray();
                JObject first = JObject.FromObject(list[0], serializer);
                foreach (JProperty prop in first.Properties())
                {
                    keys.Add(new JValue(prop.Name));
                }
                array.Add(keys);
                foreach (object item in list)
                {
                    JObject obj = JObject.FromObject(item, serializer);
                    JArray itemValues = new JArray();
                    foreach (JProperty prop in obj.Properties())
                    {
                        itemValues.Add(prop.Value);
                    }
                    array.Add(itemValues);
                }
            }
            array.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            IList list = (IList)Activator.CreateInstance(objectType);  // List<T>
            JArray array = JArray.Load(reader);
            if (array.Count > 0)
            {
                Type itemType = objectType.GetGenericArguments().Single();
                JArray keys = (JArray)array[0];
                foreach (JArray itemValues in array.Children<JArray>().Skip(1))
                {
                    JObject item = new JObject();
                    for (int i = 0; i < keys.Count; i++)
                    {
                        item.Add(new JProperty(keys[i].ToString(), itemValues[i]));
                    }
                    list.Add(item.ToObject(itemType, serializer));
                }
            }
            return list;
        }
    }
