    static class DataReaderExtensions
    {
        public static DateTime? TryGetDateTime(this DataTableReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? null : (DateTime?)reader.GetDateTime(ordinal);
        }
    }
