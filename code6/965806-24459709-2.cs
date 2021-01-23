    public static class ObjectExtensions
    {    
        public static T Clone<T>(this T source)
        {
                if (!typeof(T).IsSerializable)
                {
                    throw new ArgumentException("This type must be serializable.", "source");
                }
    
                if (Object.ReferenceEquals(source, null))
                    return default(T);
    
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new MemoryStream();
                using (stream)
                {
                    formatter.Serialize(stream, source);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (T)formatter.Deserialize(stream);
                }
         }
    }
