    ConnectionString = @"Data Source=.;Initial Catalog=n_hesabdata;Integrated Security=True";
    public int ExecuteInsertWithIdentity(string CommandText, List<SqlParameter> prms)   
    {      
        using(SqlConnection connection = new SqlConnection(ConnectionString))
        using(SqlCommand cmd = new SqlCommand(CommandText + 
                                  ";SELECT SCOPE_IDENTITY();", connection))  
        {  
           connection.Open();
           if(prms != null && prms.Count > 0)
               cmd.Parameters.AddRange(prms.ToArray());
            int lastID = Convert.ToInt32(cmd.ExecuteScalar());        
            return lastID;
        }
    }
    ....
    
    List<SqlParameter> prms = new List<SqlParameter>();  
    SqlParameter p1 = new SqlParameter() {ParameterName = "@phone", 
                                          SqlDbType = SqlDbType.NVarChar,
                                          Value = Ctm_phone.text};
    SqlParameter p2 = new SqlParameter() {ParameterName = "@Name", 
                                          SqlDbType = SqlDbType.NVarChar,
                                          Value = Ctm_name.Text};
    prms.AddRange(new SqlParameter[] {p1, p2});
    int lastOrderID = ExecuteInsertWithIdentity(@"insert into Orders  
                                                (Ctm_phone,Ctm_FullName) 
                                                VALUES (@phone, @name)", prms);
