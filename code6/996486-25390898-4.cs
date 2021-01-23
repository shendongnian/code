        string sql = "SELECT * from YourTable
                               where SomeValue=@p0 and SomeOtherValue=@p1";
        List<object> parameters = new List<object>(){
            new "Value 1",
            new "Value 2"
        }.ToArray();
    
    DbSqlQuery<SomeEntity> data = db.SomeEntity.SqlQuery(sql, parameters);
