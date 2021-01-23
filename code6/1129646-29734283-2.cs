    public sealed class Root<T>
    {
        public Data<T> data { get; set; }
    }
    [JsonConverter(typeof(GenericDataResponseConverter))]
    public sealed class Data<T>
    {
        public string Name { get; set; }
        public T DataResponse { get; set; }
    }
    class GenericDataResponseConverter : JsonConverter
    {
        Type GetDataResponseType(Type objectType)
        {
            return (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Data<>) ? objectType.GetGenericArguments()[0] : null);
        }
        public override bool CanConvert(Type objectType)
        {
            return GetDataResponseType(objectType) != null;
        }
        object ReadJsonGeneric<T>(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var data = ((Data<T>)existingValue) ?? new Data<T>();
            var obj = JObject.Load(reader);
            data.Name = (string)obj["name"];
            data.DataResponse = obj[data.Name].ToObject<T>(serializer);
            return data;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var method = GetType().GetMethod("ReadJsonGeneric", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var genericMethod = method.MakeGenericMethod(new[] { GetDataResponseType(objectType ) });
            return genericMethod.Invoke(this, new object[] { reader, objectType, existingValue, serializer });
        }
        void WriteJsonGeneric<T>(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var data = (Data<T>)value;
            var dict = new Dictionary<string, object> 
            {
                { "name", data.Name },
                { data.Name, data.DataResponse },
            };
            serializer.Serialize(writer, dict);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var method = GetType().GetMethod("WriteJsonGeneric", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var genericMethod = method.MakeGenericMethod(new[] { GetDataResponseType(value.GetType()) });
            genericMethod.Invoke(this, new object[] { writer, value, serializer });
        }
    }
