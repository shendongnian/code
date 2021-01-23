    That being said, to deal with your existing JSON, you can adapt the `IgnoreArrayTypeConverter` from [make Json.NET ignore $type if it's incompatible](http://stackoverflow.com/questions/33159959/make-json-net-ignore-type-if-its-incompatible) to use with a resizable collection:
        public class IgnoreCollectionTypeConverter : JsonConverter
        {
            public IgnoreCollectionTypeConverter() { }
            public IgnoreCollectionTypeConverter(Type ItemConverterType) 
            { 
                this.ItemConverterType = ItemConverterType; 
            }
            public Type ItemConverterType { get; set; }
            public override bool CanConvert(Type objectType)
            {
                // TODO: test with read-only collections.
                return objectType.GetCollectItemTypes().Count() == 1 && !objectType.IsDictionary() && !objectType.IsArray;
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (!CanConvert(objectType))
                    throw new JsonSerializationException(string.Format("Invalid type \"{0}\"", objectType));
                if (reader.TokenType == JsonToken.Null)
                    return null;
                var token = JToken.Load(reader);
                var itemConverter = (ItemConverterType == null ? null : (JsonConverter)Activator.CreateInstance(ItemConverterType, true));
                if (itemConverter != null)
                    serializer.Converters.Add(itemConverter);
                try
                {
                    return ToCollection(token, objectType, existingValue, serializer);
                }
                finally
                {
                    if (itemConverter != null)
                        serializer.Converters.RemoveLast(itemConverter);
                }
            }
            private static object ToCollection(JToken token, Type collectionType, object existingValue, JsonSerializer serializer)
            {
                if (token == null || token.Type == JTokenType.Null)
                    return null;
                else if (token.Type == JTokenType.Array)
                {
                    // Here we assume that existingValue already is of the correct type, if non-null.
                    existingValue = serializer.DefaultCreate<object>(collectionType, existingValue);
                    token.PopulateObject(existingValue, serializer);
                    return existingValue;
                }
                else if (token.Type == JTokenType.Object)
                {
                    var values = token["$values"];
                    if (values == null)
                        return null;
                    return ToCollection(values, collectionType, existingValue, serializer);
                }
                else
                {
                    throw new JsonSerializationException("Unknown token type: " + token.ToString());
                }
            }
            public override bool CanWrite { get { return false; } }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
