    internal static class OraclaDataReaderExtension
    {
        public static T Read<T>(this OraclaDataReader dbReader, string columnName)
        {
            return dbReader.IsDBNull(columnName) ? default(T) : (T)dbReader[columnName];
        }
    }
