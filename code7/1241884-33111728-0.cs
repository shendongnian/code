        public static string GetSafeString(SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
                return reader.GetString(index);
            else
                return string.Empty;
        }
