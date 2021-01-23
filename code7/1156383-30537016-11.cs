    //Maybe you want to make it so that any object can XML serialize itself
    //using an easy-to-use, shared syntax.
    //Your MyPoint class isn't directly concerned about XML serialization,
    //so it doesn't make sense to implement this as an instance method but
    //MyPoint can pick up this capability from this extension method.
    public static class XmlSerialization
    {
        public static string ToXml(this object valueToSerialize)
        {
            var serializer = new XmlSerializer(valueToSerialize.GetType());
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
                serializer.Serialize(writer, valueToSerialize);
            return sb.ToString();
        }
    }
    //example usage
    var point = new MyPoint();
    var pointXml = point.ToXml(); //<- from the extension method
