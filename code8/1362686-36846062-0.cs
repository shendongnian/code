        SqlParameter param;
        
        cmd1 = new SqlCommand("select password from tbl_login where username=@username, con);
    
        param = new SqlParameter("@username", SqlDbType.VarChar);
        param.Direction = ParameterDirection.Input;
        param.Value = unm;
        cmd1.Parameters.Add(param);
    
        cpaswrd = cmd1.ExecuteScalar().ToString();
