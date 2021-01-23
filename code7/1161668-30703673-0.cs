    SqlConnection conn = DB_Connect.GetConn();
    conn.Open();
    ....
    
    using(SqlCommand ....)
    {
    
    .....
    your transaction here
    .....
    
    newCmd.ExecuteNonQuery();
    
    }
    conn.Close();
