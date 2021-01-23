    List<MySqlParameter> parameters = new List<MySqlParameter>()
    {
       {new MySqlParameter() 
            { 
               ParameterName = "?user_mail", 
               MySqlDbType= MySqlDbType.VarChar,
               Value = userid.Text
             },
       {new MySqlParameter() 
            { 
               ParameterName = "?user_cell", 
               MySqlDbType= MySqlDbType.VarChar,
               Value = userid.Text
             },
   
       {new MySqlParameter() 
            { 
               ParameterName = "?userkey", 
               MySqlDbType = MySqlDbType.VarChar,
               Value = userkey.Text
             },
      
    }
    if (db.dbQuery(sql, parameters))
     ....
