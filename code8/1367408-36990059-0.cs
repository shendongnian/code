    public static class JavaScriptSerializerObjectExtensions
    {
        public static bool IsJsonArray(this object obj)
        {
            if (obj is string || obj.IsJsonObject())
                return false;
            return obj is IEnumerable;
        }
        public static IEnumerable<object> AsJsonArray(this object obj)
        {
            if (obj is string || obj.IsJsonObject())
                return null;
            return (obj as IEnumerable).Cast<object>();
        }
        public static bool IsJsonObject(this object obj)
        {
            return obj is IDictionary<string, object>;
        }
        public static IDictionary<string, object> AsJsonObject(this object obj)
        {
            return obj as IDictionary<string, object>;
        }
        public static string JsonPrimitiveToString(this object obj, bool isoDateFormat = true)
        {
            if (obj == null)
                return null; // Or return "null" if you prefer.
            else if (obj is string)
                return (string)obj;
            else if (obj.IsJsonArray() || obj.IsJsonObject())
                return new JavaScriptSerializer().Serialize(obj);
            else if (isoDateFormat && obj is DateTime)
                // Return in ISO 8601 format not idiosyncratic JavaScriptSerializer format
                // https://stackoverflow.com/questions/17301229/deserialize-iso-8601-date-time-string-to-c-sharp-datetime
                // https://msdn.microsoft.com/en-us/library/az4se3k1.aspx#Roundtrip
                return ((DateTime)obj).ToString("o");
            else
            {
                var s = new JavaScriptSerializer().Serialize(obj);
                if (s.Length > 1 && s.StartsWith("\"", StringComparison.Ordinal) && s.EndsWith("\"", StringComparison.Ordinal))
                    s = s.Substring(1, s.Length - 2);
                return s;
            }
        }
    }
