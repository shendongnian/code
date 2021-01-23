    string connection = ConfigurationManager.ConnectionStrings["PaydayLunchConnectionString1"].ConnectionString;
            SqlConnection conn = new SqlConnection(connection);
    
            SqlCommand com = new SqlCommand(
                "SELECT        TOP (1) Month " +
                "FROM          Past_Places", conn);
    
            try
            {
                conn.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    PastMonth.Text = reader["Month"].ToString();
                }
                reader.Close();
            }
            finally
            {
                conn.Close();
            }
