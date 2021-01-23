    public static class JavaScriptSerializerExtensions
    {
        public static void SerializeToStream<T>(this JavaScriptSerializer serializer, IEnumerable<T> collection, Stream stream)
        {
            if (serializer == null || collection == null || stream == null)
                throw new ArgumentNullException();
            var writer = new StreamWriter(stream, new UTF8Encoding(false));  // DO NOT DISPOSE!
            writer.Write("[");
            long count = 0;
            var sb = new StringBuilder();
            var buffer = new char[4000];
            foreach (var item in collection)
            {
                if (count > 0)
                    writer.Write(",");
                sb.Length = 0;
                serializer.Serialize(item, sb);
                writer.Write(sb, buffer);
                count++;
            }
            writer.Write("]");
            writer.Flush();
        }
    }
    public static class TextWriterExtensions
    {
        public static void Write(this TextWriter writer, StringBuilder sb, char[] buffer = null)
        {
            if (sb == null || writer == null)
                throw new ArgumentNullException();
            if (buffer != null && buffer.Length <= 0)
                throw new ArgumentException("buffer != null && buffer.Length <= 0");
            var length = sb.Length;
            if (length <= 0)
                return;
            buffer = buffer ?? new char[Math.Min(4000, length)];
            for (int index = 0; index < length; index += buffer.Length)
            {
                var count = Math.Min(length - index, buffer.Length);
                sb.CopyTo(index, buffer, 0, count);
                writer.Write(buffer, 0, count);
            }
        }
    }
