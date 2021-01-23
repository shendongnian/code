    using (SqlConnection conn = new SqlConnection("connectionString"))
    {
    SqlCommand cmd = null;
    SqlParameter prm = null;
    SqlDataAdapter dad = null;
    DataTable dt = new DataTable();
    
    cmd = new SqlCommand("SPName", conn);
    cmd.CommandType = CommandType.StoredProcedure;
                    
    conn.Open();
    dad = new SqlDataAdapter(cmd);
                    
    
    dad.Fill(dt);
    conn.Close();
    }
    
    
    using (SqlConnection conn = new SqlConnection("connectionString"))
    {
    SqlCommand cmd = null;
    SqlParameter prm = null;
    SqlDataAdapter dad = null;
    DataTable dt = new DataTable();
    
    cmd = new SqlCommand("select * from dummy",conn);
    cmd.CommandType = CommandType.StoredProcedure;
    conn.Open();
    dad = new SqlDataAdapter(cmd);
    
    
    dad.Fill(dt);
    conn.Close();
    }
