    public abstract class SomeAbstractBaseClass
    {
    }
    public class Class1 : SomeAbstractBaseClass
    {
        public string Value1 { get; set; }
    }
    public class Class2 : SomeAbstractBaseClass
    {
        public string Value2 { get; set; }
    }
    public static class SomeAbstractBaseClassSerializationHelper
    {
        public static SomeEnum SerializedType(this SomeAbstractBaseClass baseObject)
        {
            if (baseObject == null)
                return SomeEnum.None;
            if (baseObject.GetType() == typeof(Class1))
                return SomeEnum.Class1;
            if (baseObject.GetType() == typeof(Class2))
                return SomeEnum.Class2;
            throw new InvalidDataException();
        }
        public static SomeAbstractBaseClass DeserializeMember(JObject jObject, string objectName, string enumName, JsonSerializer serializer)
        {
            var someObject = jObject[objectName];
            if (someObject == null || someObject.Type == JTokenType.Null)
                return null;
            var someValue = jObject[enumName];
            if (someValue == null || someValue.Type == JTokenType.Null)
                throw new JsonSerializationException("no type information");
            switch (someValue.ToObject<SomeEnum>(serializer))
            {
                case SomeEnum.Class1:
                    return someObject.ToObject<Class1>(serializer);
                case SomeEnum.Class2:
                    return someObject.ToObject<Class2>(serializer);
                default:
                    throw new JsonSerializationException("unexpected type information");
            }
        }
    }
    public enum SomeEnum
    {
        None,
        Class1,
        Class2,
    }
    [JsonConverter(typeof(FooConverter))]
    public class Foo
    {
        [JsonCustomRead]
        public SomeEnum SomeValue { get { return SomeObject.SerializedType(); } }
        [JsonCustomRead]
        public SomeAbstractBaseClass SomeObject { get; set; }
        public string SomethingElse { get; set; }
    }
    public class FooConverter : JsonCustomReadConverter
    {
        protected override void ReadCustom(object value, JObject jObject, JsonSerializer serializer)
        {
            var foo = (Foo)value;
            foo.SomeObject = SomeAbstractBaseClassSerializationHelper.DeserializeMember(jObject, "SomeObject", "SomeValue", serializer);
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Foo).IsAssignableFrom(objectType);
        }
    }
