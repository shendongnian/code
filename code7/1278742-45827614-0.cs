        public string GetInetValue(NpgsqlDataReader dr, string columnName, String defaultValue)
        {
            var returnVal = defaultValue;
            try
            {
                returnVal = dr.IsDBNull(dr.GetOrdinal(columnName)) ? defaultValue : dr.GetFieldValue<String>(dr.GetOrdinal(columnName));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return returnVal;
        }
