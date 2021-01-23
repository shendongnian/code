        /// <summary>
        /// (extension method) Deserializes a byte array into an object.
        /// </summary>
        public static T DeserializeToObject<T>(this byte[] buffer) where T : class
        {
            using (var stream = new MemoryStream(buffer))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
