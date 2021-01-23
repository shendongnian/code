    private const string INSERT = "INSERT INTO Person VALUES (@FirstName, @LastName)";
    
    public static DbCommand INSERTCOMMAND(IPerson person)
    {
        DbCommand command = null;
        var sqlParams = new List<DbParameter>();
        MySqlEnum sqlType = SQLManagerFactory.SQLManager is SQLServerManager ? MySqlEnum.SQLServer : MySqlEnum.sqlLite
    
        if(sqlType == MySqlEnum.SQLServer)
            command = new SqlCommand(INSERT);
        else // SQLiteManager
            command = new SQLiteCommand(INSERT);
    
        sqlParams.Add(new CustomSqlParameter(sqlType ,"@FirstName", person.FirstName);
        sqlParams.Add(new CustomSqlParameter(sqlType ,"@LastName", person.LastName);
     
        command.Parameters.AddRange(sqlParams.ToArray());
        return command;
    }
