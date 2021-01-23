        public static object XmlDeserializeFromString<T>(this string objectData, int skip)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(objectData))
            {
                for (; skip > 0 && reader.Read() != -1; skip--)
                    ;
                return (T)serializer.Deserialize(reader);
            }
        }
