    internal static class OraclaDataReaderExtension
    {
        public int? ReadNullInt32(this OraclaDataReader dbReader, string columnName)
        {
            return dbReader.IsDBNull("Column2") ? null : (int?)dbReader["Column2"];
        }
    }
