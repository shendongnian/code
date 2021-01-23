    public DataTable FUNCTIONNAMEINCLASS( int id)
    {  
    try    
    {
    using (SqlConnection cn = new SqlConnection(CLASS.ConnectionString))
    {
    SqlCommand cmd = new SqlCommand("[storeprocedure]", cn);
    cn.Open();
    cmd.CommandType = CommandType.StoredProcedure;     
    cmd.Parameters.Add("@ID", SqlDbType.VarChar, 50).Value = id;
    SqlDataAdapter sda = new SqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    sda.Fill(dt);
    return dt;
    }
    }
    ## Use StoredProcedure in function ##
