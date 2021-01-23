    using System;
    using Newtonsoft.Json;
    /// <summary>
    /// Class we want to serialize.
    /// </summary>
    class ClassToSerialize
    {
        public string MyString { get; set; } = "Hello, serializer!";
        public int MyInt { get; set; } = 9;
        /// <summary>
        /// This will be null after serializing or deserializing.
        /// </summary>
        public ClassToIgnore IgnoredMember { get; set; } = new ClassToIgnore();
    }
    /// <summary>
    /// Ignore instances of this class.
    /// </summary>
    [JsonConverter(typeof(IgnoringConverter))]
    class ClassToIgnore
    {
        public string NonSerializedString { get; set; } = "This should not be serialized.";
    }
    class IgnoringConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return null;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ClassToIgnore);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new ClassToSerialize();
            var json = JsonConvert.SerializeObject(obj);
            Console.WriteLine(json);
            obj = JsonConvert.DeserializeObject<ClassToSerialize>(json);
            
            // note that obj.IgnoredMember == null at this point
            Console.ReadKey();
        }
    }
