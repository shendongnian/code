    Thus you could do:
        public static partial class JsonExtensions
        {
            public static bool IsPrimitive(this JsonToken tokenType)
            {
                switch (tokenType)
                {
                    case JsonToken.Integer:
                    case JsonToken.Float:
                    case JsonToken.String:
                    case JsonToken.Boolean:
                    case JsonToken.Undefined:
                    case JsonToken.Null:
                    case JsonToken.Date:
                    case JsonToken.Bytes:
                        return true;
                    default:
                        return false;
                }
            }
            public static IEnumerable<string> ReadPrimitives(Stream stream)
            {
                return ReadPrimitives(new StreamReader(stream));
            }
            public static IEnumerable<string> ReadPrimitives(TextReader textReader)
            {
                var reader = new JsonTextReader(textReader);
                reader.SupportMultipleContent = true;
                while (reader.Read())
                {
                    if (reader.TokenType.IsPrimitive())
                    {
                        if (reader.TokenType == JsonToken.String)
                            yield return reader.Value.ToString(); // No need for conversion
                        else
                            yield return (string)JValue.Load(reader); // Convert to string.
                    }
                }
            }
        }
