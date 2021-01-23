    using (SqlConnection conn = new SqlConnection(connstring))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand(cmdstring, conn))
        {
            cmd.ExecuteNonQuery();
        }
    }
