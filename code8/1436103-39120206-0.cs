     private void non_Query(string sql)
        {
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                using (SqlCommand com = conn.CreateCommand())
                {
                    com.CommandTimeout = 900;
                    com.CommandText = sql;
                    com.ExecuteNonQuery();
                }
                conn.Close();
            }
            
        }
