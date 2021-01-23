    /// <summary>
    /// Converts an ExpandoObject to and from JSON, handling object references.
    /// </summary>
    public class ObjectReferenceExpandoObjectConverter : JsonConverter
    {
        // Adapted from https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Converters/ExpandoObjectConverter.cs
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // can write is set to false
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return ReadValue(serializer, reader);
        }
        private object ReadValue(JsonSerializer serializer, JsonReader reader)
        {
            while (reader.TokenType == JsonToken.Comment)
            {
                if (!reader.Read())
                    throw reader.CreateException("Unexpected end when reading ExpandoObject.");
            }
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    return ReadObject(serializer, reader);
                case JsonToken.StartArray:
                    return ReadList(serializer, reader);
                default:
                    if (JsonTokenUtils.IsPrimitiveToken(reader.TokenType))
                        return reader.Value;
                    throw reader.CreateException("Unexpected token when converting ExpandoObject");
            }
        }
        private object ReadList(JsonSerializer serializer, JsonReader reader)
        {
            IList<object> list = new List<object>();
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Comment:
                        break;
                    default:
                        object v = ReadValue(serializer, reader);
                        list.Add(v);
                        break;
                    case JsonToken.EndArray:
                        return list;
                }
            }
            throw reader.CreateException("Unexpected end when reading ExpandoObject.");
        }
        private object ReadObject(JsonSerializer serializer, JsonReader reader)
        {
            IDictionary<string, object> expandoObject = null;
            object referenceObject = null;
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        string propertyName = reader.Value.ToString();
                        if (!reader.Read())
                            throw new InvalidOperationException("Unexpected end when reading ExpandoObject.");
                        object v = ReadValue(serializer, reader);
                        if (propertyName == "$ref")
                        {
                            var id = (v == null ? null : Convert.ToString(v, CultureInfo.InvariantCulture));
                            referenceObject = serializer.ReferenceResolver.ResolveReference(serializer, id);
                        }
                        else if (propertyName == "$id")
                        {
                            var id = (v == null ? null : Convert.ToString(v, CultureInfo.InvariantCulture));
                            serializer.ReferenceResolver.AddReference(serializer, id, (expandoObject ?? (expandoObject = new ExpandoObject())));
                        }
                        else
                        {
                            (expandoObject ?? (expandoObject = new ExpandoObject()))[propertyName] = v;
                        }
                        break;
                    case JsonToken.Comment:
                        break;
                    case JsonToken.EndObject:
                        if (referenceObject != null && expandoObject != null)
                            throw reader.CreateException("ExpandoObject contained both $ref and real data");
                        return referenceObject ?? expandoObject;
                }
            }
            throw reader.CreateException("Unexpected end when reading ExpandoObject.");
        }
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ExpandoObject));
        }
        public override bool CanWrite
        {
            get { return false; }
        }
    }
    public static class JsonTokenUtils
    {
        // Adapted from https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Utilities/JsonTokenUtils.cs
        public static bool IsPrimitiveToken(this JsonToken token)
        {
            switch (token)
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
    }
    public static class JsonReaderExtensions
    {
        public static JsonSerializationException CreateException(this JsonReader reader, string format, params object[] args)
        {
            // Adapted from https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/JsonPosition.cs
            var lineInfo = reader as IJsonLineInfo;
            var path = (reader == null ? null : reader.Path);
            var message = string.Format(CultureInfo.InvariantCulture, format, args);
            if (!message.EndsWith(Environment.NewLine, StringComparison.Ordinal))
            {
                message = message.Trim();
                if (!message.EndsWith(".", StringComparison.Ordinal))
                    message += ".";
                message += " ";
            }
            message += string.Format(CultureInfo.InvariantCulture, "Path '{0}'", path);
            if (lineInfo != null && lineInfo.HasLineInfo())
                message += string.Format(CultureInfo.InvariantCulture, ", line {0}, position {1}", lineInfo.LineNumber, lineInfo.LinePosition);
            message += ".";
            return new JsonSerializationException(message);
        }
    }
