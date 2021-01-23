    public static class XObjectExtensions
    {
        public static T Deserialize<T>(this XContainer element, XmlSerializer serializer = null)
        {
            if (element == null)
                throw new ArgumentNullException();
            using (var reader = element.CreateReader())
                return (T)(serializer ?? new XmlSerializer(typeof(T))).Deserialize(reader);
        }
    }
