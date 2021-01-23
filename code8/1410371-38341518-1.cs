        /// <summary>
        /// Returns a single value from the database given an Sql Command object
        /// </summary>
        /// <param name="cmd">The Sql Command object</param>
        /// <returns>string</returns>
        public static string GetSingleFromDatabase(SqlCommand cmd)
        {
            using (SqlConnection con = DbConnect()) // DbConnect() returns SqlConnection instance
            {
                cmd.Connection = con;
                try
                {
                    object returnedValue = cmd.ExecuteScalar();
                    if (returnedValue != null)
                    {
                        return returnedValue.ToString();
                    }
                    else
                        return "";
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
