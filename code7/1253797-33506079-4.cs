       using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                
                SqlCommand cmd = new SqlCommand(query, conn);
                
                try
                {
                    conn.Open();
                    SqlDataReader mdr = cmd.ExecuteReader();
                    while (mdr.Read())
                    {
                        string datetime = SafeGetDateTime(mdr, "time").ToShortTimeString();
                    }
                    conn.Close();
                    return datetime;
                 }
