    public static class JsonSerializerExtensions
    {
        public static string SerializeObject(object obj, JsonSerializerSettings settings = null)
        {
            settings = settings ?? new JsonSerializerSettings();
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                var oldError = settings.Error;
                var oldTraceWriter = settings.TraceWriter;
                var oldFormatting = settings.Formatting;
                try
                {
                    settings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    if (settings.TraceWriter == null)
                        settings.TraceWriter = new MemoryTraceWriter();
                    settings.Error = oldError + delegate(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                    {
                        jsonWriter.Flush();
                        var logSb = new StringBuilder();
                        logSb.AppendLine("Serialization error: ");
                        logSb.Append("Path: ").Append(args.ErrorContext.Path).AppendLine();
                        logSb.Append("Member: ").Append(args.ErrorContext.Member).AppendLine();
                        logSb.Append("OriginalObject: ").Append(args.ErrorContext.OriginalObject).AppendLine();
                        logSb.AppendLine("Error: ").Append(args.ErrorContext.Error).AppendLine();
                        logSb.AppendLine("Partial serialization results: ").Append(sb).AppendLine();
                        logSb.AppendLine("TraceWriter contents: ").Append(settings.TraceWriter).AppendLine();
                        logSb.AppendLine("JavaScriptSerializer serialization: ");
                        try
                        {
                            logSb.AppendLine(new JavaScriptSerializer().Serialize(obj));
                        }
                        catch (Exception ex)
                        {
                            logSb.AppendLine("Failed, error: ").AppendLine(ex.ToString());
                        }
                        logSb.AppendLine("XmlSerializer serialization: ");
                        try
                        {
                            logSb.AppendLine(obj.GetXml());
                        }
                        catch (Exception ex)
                        {
                            logSb.AppendLine("Failed, error: ").AppendLine(ex.ToString());
                        }
                        logSb.AppendLine("BinaryFormatter serialization: ");
                        try
                        {
                            logSb.AppendLine(BinaryFormatterExtensions.ToBase64String(obj));
                        }
                        catch (Exception ex)
                        {
                            logSb.AppendLine("Failed, error: ").AppendLine(ex.ToString());
                        }
                        Debug.WriteLine(logSb);
                    };
                    var serializer = JsonSerializer.CreateDefault(settings);
                    serializer.Serialize(jsonWriter, obj);
                }
                finally
                {
                    settings.Error = oldError;
                    settings.TraceWriter = oldTraceWriter;
                    settings.Formatting = oldFormatting;
                }
            }
            return sb.ToString();
        }
    }
    public static class XmlSerializerExtensions
    {
        public static T LoadFromXML<T>(this string xmlString)
        {
            using (StringReader reader = new StringReader(xmlString))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
            }
        }
        public static string GetXml<T>(this T obj)
        {
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "  " };
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    new XmlSerializer(obj.GetType()).Serialize(xmlWriter, obj);
                return textWriter.ToString();
            }
        }
    }
    public static class BinaryFormatterExtensions
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
            return FromBase64String<T>(data, null);
        }
        public static T FromBase64String<T>(string data, BinaryFormatter formatter)
        {
            using (var stream = new MemoryStream(Convert.FromBase64String(data)))
            {
                formatter = (formatter ?? new BinaryFormatter());
                var obj = formatter.Deserialize(stream);
                if (obj is T)
                    return (T)obj;
                return default(T);
            }
        }
    }
