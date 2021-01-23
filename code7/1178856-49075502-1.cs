    public static class IDataReaderExtensions
    {
        public static DateTime GetDateTimeOrMinValue(this IDataReader dr, int position)
        {
            if (dr.IsDBNull(position))
            {
                return DateTime.MinValue;
            }
            return dr.GetDateTime(position);
        }
        public static DateTime? GetDateTimeOrNull(this IDataReader dr, int position)
        {
            if (dr.IsDBNull(position))
            {
                return null;
            }
            return dr.GetDateTime(position);
        }
    }
