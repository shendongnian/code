    ConnectionString = @"Data Source=.;Initial Catalog=n_hesabdata;Integrated Security=True";
    public int ExecuteInsertWithIdentity(string CommandText, List<SqlParameter> prms)   
    {      
        using(SqlConnection connection = new SqlConnection(ConnectionString))
        using(SqlCommand cmd = new SqlCommand(CommandText + 
                                  ";SELECT SCOPE_IDENTITY();", connection))  
        {  
           if(prms != null && prms.Count > 0)
               command.Parameters.AddRange(prms.ToArray());
            int lastID = Convert.ToInt32(command.ExecuteScalar());        
            return lastID;
        }
    }
    ....
    
    List<SqlParameter> prms = new List<SqlParameter>();    
    prms.Add("@phone", Ctm_phone.text);
    prms.Add("@name", Ctm_name.Text);
    int lastOrderID = ExecuteInsertWithIdentity(@"insert into Orders  
                                                (Ctm_phone,Ctm_FullName) 
                                                VALUES (@phone, @name)", prms);
