    SqlConnection conn = DB_Connect.GetConn();
    conn.Open();
    ....
    
    using(SqlCommand ....)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            .....
            your transaction here
            .....
            newCmd.Parameters.Clear();
            ...filling parameter
            newCmd.ExecuteNonQuery();
        }
    }
    conn.Close();
