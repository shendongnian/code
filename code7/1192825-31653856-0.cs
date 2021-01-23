    class Program
    {
        static void Main(string[] args)
        {
            const string json = @"{
                    'Name': 'abc',
                    'Type':'Type4'
                }";
            
            // uncomment this if you want to use default value other then default enum first value
            //var settings = new JsonSerializerSettings();
            //settings.Converters.Add(new FooTypeEnumConverter { DefaultValue = FooType.Type3 });
            //var x = JsonConvert.DeserializeObject<Foo>(json, settings);
            
            var x = JsonConvert.DeserializeObject<Foo>(json);
        }
    }
    public class Foo
    {
        public string Name { get; set; }
        public FooType Type { get; set; }
    }
    public enum FooType
    {
        Type1,
        Type2,
        Type3
    }
    public class FooTypeEnumConverter : StringEnumConverter
    {
        public FooType DefaultValue { get; set; }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch (JsonSerializationException)
            {
                return DefaultValue;
            }
        }
    }
