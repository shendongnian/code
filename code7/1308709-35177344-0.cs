    public static class Extension
    {
        public static T Deserialize<T>(this XmlSerializer serializer, StreamReader streamReader)
        {
            try
            {
                return (T) serializer.Deserialize(streamReader);
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }
    }
