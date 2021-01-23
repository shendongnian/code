    public static class DataContractSerializerHelper
    {
        private static readonly XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Indent = true, IndentChars = "  " };
        public static string SerializeToString<T>(T from)
        {
            try
            {
                using (var ms = new MemoryStream())
                using (var xw = XmlWriter.Create(ms, xmlWriterSettings))
                {
                    var serializer = new DataContractSerializer(from.GetType());
                    serializer.WriteObject(xw, from);
                    xw.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    var reader = new StreamReader(ms);
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new SerializationException(string.Format("Error serializing \"{0}\"", from), ex);
            }
        }
        public static void SerializeToWriter<T>(T value, TextWriter writer)
        {
            try
            {
                using (var xw = XmlWriter.Create(writer, xmlWriterSettings))
                {
                    var serializer = new DataContractSerializer(value.GetType());
                    serializer.WriteObject(xw, value);
                }
            }
            catch (Exception ex)
            {
                throw new SerializationException(string.Format("Error serializing \"{0}\"", value), ex);
            }
        }
        public static void SerializeToStream(object obj, Stream stream)
        {
            if (obj == null) 
                return;
            using (var xw = XmlWriter.Create(stream, xmlWriterSettings))
            {
                var serializer = new DataContractSerializer(obj.GetType());
                serializer.WriteObject(xw, obj);
            }
        }
    }
