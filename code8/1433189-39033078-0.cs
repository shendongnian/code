    SqlCommand sql = new SqlCommand();
    SqlParameter[] parameter = {
    new SqlParameter("@name", "Test"), 
    new SqlParameter("@age", "24")};
    
    
    sql.Parameters.Add(parameter);
