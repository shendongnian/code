    using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
        conn.Open();
        using (SqlDataAdapter dbdata = new SqlDataAdapter(strSql, conn))
        {
            dbdata.Fill(table);
        }
        conn.Close();
    }
