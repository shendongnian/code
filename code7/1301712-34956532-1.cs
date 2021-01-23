    internal static class OraclaDataReaderExtension
    {
        public int? ReadNullInt32(this OraclaDataReader dbReader, string columnName)
        {
            return dbReader.IsDBNull(columnName) ? null : (int?)dbReader[columnName];
        }
    }
