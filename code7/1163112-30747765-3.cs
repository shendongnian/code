    public static class XObjectExtensions
    {
        public static T Deserialize<T>(this XContainer element)
        {
            return element.Deserialize<T>(new XmlSerializer(typeof(T)));
        }
        public static T Deserialize<T>(this XContainer element, XmlSerializer serializer)
        {
            using (var reader = element.CreateReader())
            {
                object result = serializer.Deserialize(reader);
                if (result is T)
                    return (T)result;
            }
            return default(T);
        }
    }
