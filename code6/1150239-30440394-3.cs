    protected static DBType GetDBType(string odbcConnStr)
    {
     DbType dbType = DbType.UNSUPPORTED;
     try
     {
      using (cn = new OdbcConnection(odbcConnStr))
      {
        if (cn.State != ConnectionState.Open) cn.Open();
        dbType = GetDbType(cn, dbType)
        if (dbType > 0) return dbType;
        var sqlVersionQuery = "SELECT * FROM v$version"; 
        dbType = GetDbType(cn, sqlVersionQuery, DBType.MYSQL)
        if (dbType > 0) return dbType;
        sqlVersionQuery = "SELECT @@version, @@version_comment FROM dual"; 
        dbType = GetDbType(cn, sqlVersionQuery, DBType.Oracle)
        if (dbType > 0) return dbType;
        sqlVersionQuery = "SELECT @@version"; 
        int dbType = GetDbType(cn, sqlVersionQuery, DBType.MSSQL)
        if (dbType > 0) return dbType;
        sqlVersionQuery = "SELECT * FROM v$version"; 
        int dbType = GetDbType(cn, sqlVersionQuery, DBType.POSTGRESQL)
        if (dbType > 0) return dbType;
      }
     }
     catch(Exception connEx) { }
     return dbType;
    }
    public enum DBType
    {
        UNSUPPORTED = 0,
        MYSQL = 1,
        ORACLE = 2,
        MSSQL = 3,
        POSTGRESQL = 4,
        JET = 5
    }
    private static DbType GetDbType(OdbcConnection cn, DBType dbType)
    {
        try
        {
            if (cn.Driver == "odbcjt32.dll") dbType = DBType.JET;
        }
        catch(Exception ex) { }
       return dbType;
     }
    private static DbType GetDbType(OdbcConnection cn, string sqlVersionQuery, DBType dbType)
    {
      DbType t = DbType.UNSUPPORTED;
      try
      {
      using (var cmd = cn.CreateCommand()) {
      cmd.CommandText = sqlVersionQuery;
        try
        {
           using (var reader = cmd.ExecuteReader()) 
           {
               if (reader.HasRows) t = dbType;
           }
        }
        catch (Exception cmdEx) { }
      }
      catch (Exception ex) { }           
      }
     return t;
    }
