    internal class Inherited
    {
        public int MyProperty { get; set; }
        public int MyProperty2 { get; set; }
    }
    internal class CustomConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Inherited);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var data = value as Inherited;
            if (data != null)
            {
                writer.WriteStartObject();
                foreach (var item in typeof(Inherited).GetProperties())
                {
                    writer.WritePropertyName(item.Name);
                    switch (item.PropertyType.Name)
                    {
                        case "Int32":
                            {
                                writer.WriteValue(default(int) == (int)item.GetValue(data, null) ? "" : item.GetValue(data, null).ToString());
                                break;
                            }
                    }
                }
                writer.WriteEnd();
            }
        }
    }
    
    JsonSerializerSettings obj = new JsonSerializerSettings();
    obj.Converters.Add(new CustomConverter());
    var result = JsonConvert.SerializeObject(new Inherited(0) { MyProperty = 0, MyProperty2 = 0 }, obj);
