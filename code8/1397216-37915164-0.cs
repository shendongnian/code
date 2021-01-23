     var p = new DynamicParameters();
     p.Add("@a", 11);
     p.Add("@b", dbType: DbType.Int32, direction: ParameterDirection.Output);
     p.Add("@c", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
    
     cnn.Execute("spMagicProc", p, commandType: CommandType.StoredProcedure); 
    
     int b = p.Get<int>("@b");
     int c = p.Get<int>("@c");
