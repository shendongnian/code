    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using FluentAssertions;
    using Newtonsoft.Json;
    using Xunit;
    namespace Serialization
    {
        public class ValueObjectSerializationTests
        {
            class SomeClass
            {
                public IPAddress IPAddress { get; set; }
            }
    
            [Fact]
            public void FactMethodName()
            {
                var given = new SomeClass
                {
                    IPAddress = new IPAddress("192.168.1.2")
                };
    
                var jsonSerializerSettings = new JsonSerializerSettings()
                {
                    Converters = new List<JsonConverter>
                                 {
                                    new ValueObjectConverter()
                                 }
                };
                var json = JsonConvert.SerializeObject(given, jsonSerializerSettings);
    
                var result = JsonConvert.DeserializeObject<SomeClass>(json, jsonSerializerSettings);
    
                var expected = new SomeClass
                {
                    IPAddress = new IPAddress("192.168.1.2")
                };
    
                json.Should().Be("{\"IPAddress\":\"192.168.1.2\"}");
                expected.ShouldBeEquivalentTo(result);
            }
        }
    
        public class IPAddress:IValueObject
        {
            public IPAddress(string value)
            {
                Value = value;
            }
    
            public object GetValue()
            {
                return Value;
            }
    
            public string Value { get; private set; }
        }
    
        public interface IValueObject
        {
            object GetValue();
        }
    
        public class ValueObjectConverter : JsonConverter
        {
            private static readonly ConcurrentDictionary<Type, Type> ConstructorArgumenTypes = new ConcurrentDictionary<Type, Type>();
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (!(value is IValueObject valueObject))
                {
                    return;
                }
    
                serializer.Serialize(writer, valueObject.GetValue());
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var parameterType = ConstructorArgumenTypes.GetOrAdd(
                    objectType,
                    t =>
                    {
                        var constructorInfo = objectType.GetConstructors(BindingFlags.Public | BindingFlags.Instance).First();
                        var parameterInfo = constructorInfo.GetParameters().Single();
                        return parameterInfo.ParameterType;
                    });
    
                var value = serializer.Deserialize(reader, parameterType);
                return Activator.CreateInstance(objectType, new[] { value });
            }
    
            public override bool CanConvert(Type objectType)
            {
                return typeof(IValueObject).IsAssignableFrom(objectType);
            }
        }
    }
