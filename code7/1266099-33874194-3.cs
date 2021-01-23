    public MyReturnModel DoLogin(logintable u)
    {
       using (var db = new MyContext())
       {
           var cmd = db.Database.Connection.CreateCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "splogindata";
    
          var u = cmd.CreateParameter();
          u.DbType = DbType.String;
          u.ParameterName = "@Username";
          u.Value = u.Username;
          cmd.Parameters.Add(u);
    
          var p = cmd.CreateParameter();
          p.DbType = DbType.String;
          p.ParameterName = "@Password";
          p.Value = u.Username;
          cmd.Parameters.Add(p);
    
    
          db.Database.Connection.Open();
          var reader = cmd.ExecuteReader();
          //  return list as ObjectList
          var results = ((IObjectContextAdapter) db).ObjectContext.Translate<MyReturnModel>(reader);
          //  cast to entity
          var returnModel = (from s in results select s).FirstOrDefault();
          db.Database.Connection.Close();
       }
    
       return returnModel;
    }
