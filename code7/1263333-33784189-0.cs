    string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
    using (SqlConnection con = new SqlConnection(Properties.Settings.Default.AlhusainSoundDBConnectionString))
    using (SqlCommand cmd = new SqlCommand(sql, con))
    {
        con.Open();
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
                // do something with each table
            }
        }
    }
