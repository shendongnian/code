    public string CreateSQL(string userName,string password)
    {
      string sql="SELECT * FROM Table WHERE";
    
      if(!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
    {
       sql+=" UserName='"+userName+"' AND Password='"+password+"'";
    }
    else if(!string.IsNullOrWhiteSpace(userName))
    {
      sql+=" UserName='"+userName+"'";
    }
    else if(!string.IsNullOrWhiteSpace(password))
    {
      sql+=" Password='"+password+"'";
    }
    else
    {
     sql=null;
    }
    
    return sql;
    } 
 
