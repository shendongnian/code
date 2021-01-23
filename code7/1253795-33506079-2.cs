       using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                try
                {
                    SqlDataReader mdr = cmd.ExecuteReader();
                    while (mdr.Read())
                    {
                        DateTime datetime = SafeGetDateTime(mdr, "time").ToShortTimeString();
                    }
                    conn.Close();
                    return datetime;
                 }
