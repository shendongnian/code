    /// <summary>
    /// Converts an ExpandoObject to and from JSON.
    /// Adapted from https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Converters/ExpandoObjectConverter.cs
    /// License: https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md
    /// </summary>
    public class TypeNameHandlingExpandoObjectConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // can write is set to false
        }
        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return ReadValue(reader, serializer);
        }
        private object ReadValue(JsonReader reader, JsonSerializer serializer)
        {
            if (!reader.MoveToContent())
            {
                throw JsonSerializationExceptionHelper.Create(reader, "Unexpected end when reading ExpandoObject.");
            }
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    return ReadObject(reader, serializer);
                case JsonToken.StartArray:
                    return ReadList(reader, serializer);
                default:
                    if (JsonTokenUtils.IsPrimitiveToken(reader.TokenType))
                    {
                        return reader.Value;
                    }
                    throw JsonSerializationExceptionHelper.Create(reader, string.Format("Unexpected token when converting ExpandoObject: {0}", reader.TokenType));
            }
        }
        private object ReadList(JsonReader reader, JsonSerializer serializer)
        {
            IList<object> list = new List<object>();
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Comment:
                        break;
                    default:
                        object v = ReadValue(reader, serializer);
                        list.Add(v);
                        break;
                    case JsonToken.EndArray:
                        return list;
                }
            }
            throw JsonSerializationExceptionHelper.Create(reader, "Unexpected end when reading ExpandoObject.");
        }
        private object ReadObject(JsonReader reader, JsonSerializer serializer)
        {
            if (serializer.TypeNameHandling != TypeNameHandling.None)
            {
                var obj = JObject.Load(reader);
                Type polymorphicType = null;
                var polymorphicTypeString = (string)obj["$type"];
                if (polymorphicTypeString != null)
                {
                    if (serializer.TypeNameHandling != TypeNameHandling.None)
                    {
                        string typeName, assemblyName;
                        ReflectionUtils.SplitFullyQualifiedTypeName(polymorphicTypeString, out typeName, out assemblyName);
                        polymorphicType = serializer.Binder.BindToType(assemblyName, typeName);
                    }
                    obj.Remove("$type");
                }
                if (polymorphicType == null || polymorphicType == typeof(ExpandoObject))
                {
                    using (var subReader = obj.CreateReader())
                        return ReadExpandoObject(subReader, serializer);
                }
                else
                {
                    using (var subReader = obj.CreateReader())
                        return serializer.Deserialize(subReader, polymorphicType);
                }
            }
            else
            {
                return ReadExpandoObject(reader, serializer);
            }
        }
        private object ReadExpandoObject(JsonReader reader, JsonSerializer serializer)
        {
            IDictionary<string, object> expandoObject = new ExpandoObject();
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        string propertyName = reader.Value.ToString();
                        if (!reader.Read())
                        {
                            throw JsonSerializationExceptionHelper.Create(reader, "Unexpected end when reading ExpandoObject.");
                        }
                        object v = ReadValue(reader, serializer);
                        expandoObject[propertyName] = v;
                        break;
                    case JsonToken.Comment:
                        break;
                    case JsonToken.EndObject:
                        return expandoObject;
                }
            }
            throw JsonSerializationExceptionHelper.Create(reader, "Unexpected end when reading ExpandoObject.");
        }
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// 	<c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ExpandoObject));
        }
        /// <summary>
        /// Gets a value indicating whether this <see cref="JsonConverter"/> can write JSON.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this <see cref="JsonConverter"/> can write JSON; otherwise, <c>false</c>.
        /// </value>
        public override bool CanWrite
        {
            get { return false; }
        }
    }
    internal static class JsonTokenUtils
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
    internal static class JsonReaderExtensions
    {
        // Adapted from internal bool JsonReader.MoveToContent()
        // https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/JsonReader.cs#L1145
        public static bool MoveToContent(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            JsonToken t = reader.TokenType;
            while (t == JsonToken.None || t == JsonToken.Comment)
            {
                if (!reader.Read())
                {
                    return false;
                }
                t = reader.TokenType;
            }
            return true;
        }
    }
    internal static class JsonSerializationExceptionHelper
    {
        public static JsonSerializationException Create(this JsonReader reader, string format, params object[] args)
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
    internal static class ReflectionUtils
    {
        // Utilities taken from https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Utilities/ReflectionUtils.cs
        // I couldn't find a way to access these directly.
        public static void SplitFullyQualifiedTypeName(string fullyQualifiedTypeName, out string typeName, out string assemblyName)
        {
            int? assemblyDelimiterIndex = GetAssemblyDelimiterIndex(fullyQualifiedTypeName);
            if (assemblyDelimiterIndex != null)
            {
                typeName = fullyQualifiedTypeName.Substring(0, assemblyDelimiterIndex.GetValueOrDefault()).Trim();
                assemblyName = fullyQualifiedTypeName.Substring(assemblyDelimiterIndex.GetValueOrDefault() + 1, fullyQualifiedTypeName.Length - assemblyDelimiterIndex.GetValueOrDefault() - 1).Trim();
            }
            else
            {
                typeName = fullyQualifiedTypeName;
                assemblyName = null;
            }
        }
        private static int? GetAssemblyDelimiterIndex(string fullyQualifiedTypeName)
        {
            int scope = 0;
            for (int i = 0; i < fullyQualifiedTypeName.Length; i++)
            {
                char current = fullyQualifiedTypeName[i];
                switch (current)
                {
                    case '[':
                        scope++;
                        break;
                    case ']':
                        scope--;
                        break;
                    case ',':
                        if (scope == 0)
                        {
                            return i;
                        }
                        break;
                }
            }
            return null;
        }
    }
