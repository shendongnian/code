    public static DbCommand INSERTCOMMAND(IPerson person)
    {
        var sqlParams = new List<DbParameter>();
        var sql = SQLManagerFactory.SQLManager; // or MyOwnSQLManager
    
        var command = sql.CreateCommand(INSERT);
        sqlParams.Add(sql.CreateParameter("@FirstName", person.FirstName));
        sqlParams.Add(sql.CreateParameter("@LastName", person.LastName));
    
        command.Parameters.AddRange(sqlParams.ToArray());
        return command;
    }
