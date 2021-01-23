        public static DateTime SafeGetDateTime(SqlDataReader reader, string colName)
        {
            if (!reader.IsDBNull(reader.GetOrdinal(colName)))
            {
                return reader.GetDateTime(reader.GetOrdinal(colName));
            }
            return DateTime.MinValue;
        }
