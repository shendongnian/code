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
                string tableName= dr["TABLE_NAME"].ToString();
                // OR
                // string tableName = dr[0].ToString();
                // OR
                // string tableName = dr.GetString(0);
            }
        }
    }
