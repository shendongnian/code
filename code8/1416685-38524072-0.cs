    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var a = new A();
                var str = JsonConvert.SerializeObject(a, new JsonSerializerSettings()
                {
                    Converters = new List<JsonConverter>()
                    {
                        new BTypeJsonConverter()
                    }
                });
            }
        }
    
        public class A
        {
            public string Name { get; } = "Johny Bravo";
            public B ComplexProperty { get; } = new B();
        }
    
        public class B
        {
            public string Prop1 { get; } = "value1";
            public string Prop2 { get; } = "value2";
            public int Prop3 { get; } = 100;
    
            public override string ToString()
            {
                return this.Prop3.ToString();
            }
        }
    
        public class BTypeJsonConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var b = value as B;
                if (b == null) return;
                writer.WriteValue(b.ToString());
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(B);
            }
        }
    }
