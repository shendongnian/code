    /// <summary>
    /// Converts a <see cref="DataTable"/> to and from JSON.
    /// </summary>
    public class TypeInferringDataTableConverter : Newtonsoft.Json.Converters.DataTableConverter
    {
        // Adapted from https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Converters/DataTableConverter.cs
        // Original license: https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md
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
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            DataTable dt = existingValue as DataTable;
            if (dt == null)
            {
                // handle typed datasets
                dt = (objectType == typeof(DataTable))
                    ? new DataTable()
                    : (DataTable)Activator.CreateInstance(objectType);
            }
            // DataTable is inside a DataSet
            // populate the name from the property name
            if (reader.TokenType == JsonToken.PropertyName)
            {
                dt.TableName = (string)reader.Value;
                reader.ReadAndAssert();
                if (reader.TokenType == JsonToken.Null)
                {
                    return dt;
                }
            }
            if (reader.TokenType != JsonToken.StartArray)
            {
                throw JsonSerializationExceptionHelper.Create(reader, "Unexpected JSON token when reading DataTable. Expected StartArray, got {0}.".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
            }
            reader.ReadAndAssert();
            var ambiguousColumnTypes = new HashSet<string>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                CreateRow(reader, dt, serializer, ambiguousColumnTypes);
                reader.ReadAndAssert();
            }
            return dt;
        }
        private static void CreateRow(JsonReader reader, DataTable dt, JsonSerializer serializer, HashSet<string> ambiguousColumnTypes)
        {
            DataRow dr = dt.NewRow();
            reader.ReadAndAssert();
            while (reader.TokenType == JsonToken.PropertyName)
            {
                string columnName = (string)reader.Value;
                reader.ReadAndAssert();
                DataColumn column = dt.Columns[columnName];
                if (column == null)
                {
                    bool isAmbiguousType;
                    Type columnType = GetColumnDataType(reader, out isAmbiguousType);
                    column = new DataColumn(columnName, columnType);
                    dt.Columns.Add(column);
                    if (isAmbiguousType)
                        ambiguousColumnTypes.Add(columnName);
                }
                else if (ambiguousColumnTypes.Contains(columnName))
                {
                    bool isAmbiguousType;
                    Type newColumnType = GetColumnDataType(reader, out isAmbiguousType);
                    if (!isAmbiguousType)
                        ambiguousColumnTypes.Remove(columnName);
                    if (newColumnType != column.DataType)
                    {
                        column = ReplaceColumn(dt, column, newColumnType, serializer);
                    }
                }
                if (column.DataType == typeof(DataTable))
                {
                    if (reader.TokenType == JsonToken.StartArray)
                    {
                        reader.ReadAndAssert();
                    }
                    DataTable nestedDt = new DataTable();
                    var nestedUnknownColumnTypes = new HashSet<string>();
                    while (reader.TokenType != JsonToken.EndArray)
                    {
                        CreateRow(reader, nestedDt, serializer, nestedUnknownColumnTypes);
                        reader.ReadAndAssert();
                    }
                    dr[columnName] = nestedDt;
                }
                else if (column.DataType.IsArray && column.DataType != typeof(byte[]))
                {
                    if (reader.TokenType == JsonToken.StartArray)
                    {
                        reader.ReadAndAssert();
                    }
                    List<object> o = new List<object>();
                    while (reader.TokenType != JsonToken.EndArray)
                    {
                        o.Add(reader.Value);
                        reader.ReadAndAssert();
                    }
                    Array destinationArray = Array.CreateInstance(column.DataType.GetElementType(), o.Count);
                    Array.Copy(o.ToArray(), destinationArray, o.Count);
                    dr[columnName] = destinationArray;
                }
                else
                {
                    dr[columnName] = (reader.Value != null) ? serializer.Deserialize(reader, column.DataType) : DBNull.Value;
                }
                reader.ReadAndAssert();
            }
            dr.EndEdit();
            dt.Rows.Add(dr);
        }
        static object RemapValue(object oldValue, Type newType, JsonSerializer serializer)
        {
            if (oldValue == null)
                return null;
            if (oldValue == DBNull.Value)
                return oldValue;
            return JToken.FromObject(oldValue, serializer).ToObject(newType, serializer);
        }
        private static DataColumn ReplaceColumn(DataTable dt, DataColumn column, Type newColumnType, JsonSerializer serializer)
        {
            var newValues = Enumerable.Range(0, dt.Rows.Count).Select(i => dt.Rows[i]).Select(r => RemapValue(r[column], newColumnType, serializer)).ToList();
            var ordinal = column.Ordinal;
            var name = column.ColumnName;
            var @namespace = column.Namespace;
            var newColumn = new DataColumn(name, newColumnType);
            newColumn.Namespace = @namespace;
            dt.Columns.Remove(column);
            dt.Columns.Add(newColumn);
            newColumn.SetOrdinal(ordinal);
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i][newColumn] = newValues[i];
            return newColumn;
        }
        private static Type GetColumnDataType(JsonReader reader, out bool isAmbiguous)
        {
            JsonToken tokenType = reader.TokenType;
            switch (tokenType)
            {
                case JsonToken.Integer:
                case JsonToken.Boolean:
                case JsonToken.Float:
                case JsonToken.String:
                case JsonToken.Date:
                case JsonToken.Bytes:
                    isAmbiguous = false;
                    return reader.ValueType;
                case JsonToken.Null:
                case JsonToken.Undefined:
                    isAmbiguous = true;
                    return typeof(string);
                case JsonToken.StartArray:
                    reader.ReadAndAssert();
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        isAmbiguous = false;
                        return typeof(DataTable); // nested datatable
                    }
                    else
                    {
                        isAmbiguous = false;
                        bool innerAmbiguous;
                        // Handling ambiguity in array entries is not yet implemented because the first non-ambiguous entry in the array
                        // might occur anywhere in the sequence, requiring us to scan the entire array to determine the type, 
                        // e.g., given: [null, null, null, 314, null]
                        // we would need to scan until the 314 value, and do:
                        // return typeof(Nullable<>).MakeGenericType(new[] { reader.ValueType }).MakeArrayType();
                        Type arrayType = GetColumnDataType(reader, out innerAmbiguous);
                        return arrayType.MakeArrayType();
                    }
                default:
                    throw JsonSerializationExceptionHelper.Create(reader, "Unexpected JSON token when reading DataTable: {0}".FormatWith(CultureInfo.InvariantCulture, tokenType));
            }
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
    internal static class StringUtils
    {
        // Adapted from https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Utilities/StringUtils.cs
        public static string FormatWith(this string format, IFormatProvider provider, object arg0)
        {
            return format.FormatWith(provider, new[] { arg0 });
        }
        private static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            return string.Format(provider, format, args);
        }
    }
    internal static class JsonReaderExtensions
    {
        public static void ReadAndAssert(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");
            if (!reader.Read())
            {
                throw JsonSerializationExceptionHelper.Create(reader, "Unexpected end when reading JSON.");
            }
        }
    }
