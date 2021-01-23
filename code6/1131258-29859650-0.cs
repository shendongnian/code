    public static class BinaryFormatterHelper
    {
        public static string ToBase64String<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, obj);
                return Convert.ToBase64String(stream.GetBuffer(), 0, checked((int)stream.Length)); // Throw an exception on overflow.
            }
        }
        public static T FromBase64String<T>(string data)
        {
            using (var stream = new MemoryStream(Convert.FromBase64String(data)))
            {
                var formatter = new BinaryFormatter();
                var obj = formatter.Deserialize(stream);
                if (obj is T)
                    return (T)obj;
                return default(T);
            }
        }
    }
