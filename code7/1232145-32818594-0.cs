      public class MyClass
        {
            public int Id { get; set; }
            [JsonProperty("Names"), JsonConverter(typeof(NamesConverter))]
            public IList<string> Names { get; protected set; }
            [JsonProperty("ClassTypes"), JsonConverter(typeof(TypesConverter))]
            public IList<Types> ClassTypes { get; protected set; }
            public StatusType Status { get; set; }
            [JsonProperty("DOB"), JsonConverter(typeof(DateTimeConverter))]
            public DateTime DOB { get; set; }
    
            public MyClass()
            {
                Names = new List<string>();
                ClassTypes = new List<Types>();
                Status = StatusType.Active;
            }
    
            public override string ToString()
            {
                return
                    string.Format("ID: {0}\nNames:\n{1}\nClassTypes:\n{2}Status: {3}\nDOB: {4}",
                    Id, string.Join("\n", Names), string.Join("\n", ClassTypes), Status, DOB);
            }
        }
        public class Types
        {
            public int TypeId { get; set; }
            public string TypeName { get; set; }
    
            public override string ToString()
            {
                return string.Format("\tTypeId: {0}\n\tTypeName: {1}\n", TypeId, TypeName);
            }
        }
    
        public enum StatusType
        {
            Active = 0,
            InActive = 1
        }
    
        class NamesConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(Dictionary<string, string>).IsAssignableFrom(objectType);
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return serializer.Deserialize<Dictionary<string, string>>(reader).Values.ToList();
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
        }
        class TypesConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(Dictionary<string,List<Types>>).IsAssignableFrom(objectType);
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return serializer.Deserialize<Dictionary<string,List<Types>>>(reader)
                    .Values.First().ToList();
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
        }
        class DateTimeConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(string).IsAssignableFrom(objectType);
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return DateTime.ParseExact(serializer.Deserialize<string>(reader), @"dd\/MM\/yyyy", null);
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
        }
...
        var jsonobj = JsonConvert.DeserializeObject<MyClass>(json);
        Console.WriteLine(jsonobj);
