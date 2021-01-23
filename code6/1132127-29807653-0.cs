    static class DataReaderExtensions
    {
        public static DateTime? TryGetDateTime(this DataTableReader reader, int ordinal)
        {
            try
            {
                return reader.GetDateTime(ordinal);
            }
            catch (Exception) { return null; }
        }
    }
