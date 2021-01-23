    public static class GenericSerializer
    {
        public static string Serialize<T>(T value)
        {
            using (var stringWriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringWriter, value);
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
