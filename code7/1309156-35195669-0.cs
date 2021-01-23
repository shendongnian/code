    public class JsonConvertEnum : JavaScriptPrimitiveConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                yield return typeof(Enum);
            }
        }
        public override object Deserialize(
            object primitiveValue, Type type, JavaScriptSerializer serializer)
        {
            if (!type.IsEnum)
            {
                return null;
            }
            return Enum.Parse(type, (string)primitiveValue);
        }
        public override object Serialize(
            object obj, JavaScriptSerializer serializer)
        {
            if (!obj.GetType().IsEnum)
            {
                return null;
            }
            return obj.ToString();
        }
    }
