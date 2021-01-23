    public class GenericSearchResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var instance = Activator.CreateInstance(objectType);
    
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var property = objectType.GetProperty(reader.Value.ToString());
                    if (property == null)
                    {
                        continue;
                    }
    
                    reader.Read();
    
                    switch (reader.TokenType)
                    {
                            case JsonToken.StartArray:
                            var array = JArray.Load(reader);
                            var listInstance = (IList) Activator.CreateInstance(property.PropertyType);
                            var listObjectType = property.PropertyType.GetGenericArguments().First();
                            foreach (var child in array)
                            {
                                var listObjectInstance = Activator.CreateInstance(listObjectType);
                                var propertyIndex = 0;
                                foreach (var subProperty in listObjectType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                                {
                                    var childValue = child[propertyIndex].ToObject(subProperty.PropertyType);
                                    subProperty.SetValue(listObjectInstance, childValue, null);
                                    propertyIndex++;
                                }
                                listInstance.Add(listObjectInstance);
                            }
                                    
                            property.SetValue(instance, listInstance);
                            break;
    
                        default:
                            var value = reader.Value;
                            var typedValue = Convert.ChangeType(value, property.PropertyType);
                            property.SetValue(instance, typedValue, null);
                            break;
                    }
                }
            }
    
            return instance;
        }
    
        public override bool CanWrite => false;
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
