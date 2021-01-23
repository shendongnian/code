    public class OnlyStringEnumConverter : StringEnumConverter
    {
        public OnlyStringEnumConverter()
        {
            AllowIntegerValues = false;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!AllowIntegerValues && reader.TokenType == JsonToken.String)
            {
                string s = reader.Value.ToString().Trim();
                if (!String.IsNullOrEmpty(s))
                {
                    if (char.IsDigit(s[0]) || s[0] == '-' || s[0] == '+')
                    {
                        string message = String.Format(CultureInfo.InvariantCulture, "Value '{0}' is not allowed for enum '{1}'.", s, objectType.FullName);
                        string formattedMessage = FormatMessage(reader as IJsonLineInfo, reader.Path, message);
                        throw new JsonSerializationException(formattedMessage);
                    }
                }
            }
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
        // Copy of internal method in NewtonSoft.Json.JsonPosition, to get the same formatting as a standard JsonSerializationException
        private static string FormatMessage(IJsonLineInfo lineInfo, string path, string message)
        {
            if (!message.EndsWith(Environment.NewLine, StringComparison.Ordinal))
            {
                message = message.Trim();
                if (!message.EndsWith("."))
                {
                    message += ".";
                }
                message += " ";
            }
            message += String.Format(CultureInfo.InvariantCulture, "Path '{0}'", path);
            if (lineInfo != null && lineInfo.HasLineInfo())
            {
                message += String.Format(CultureInfo.InvariantCulture, ", line {0}, position {1}", lineInfo.LineNumber, lineInfo.LinePosition);
            }
            message += ".";
            return message;
        }
    }
