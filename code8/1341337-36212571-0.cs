    public Configuration()
    {
       AutomaticMigrationsEnabled = false;
       SetSqlGenerator("System.Data.SqlClient", new EntityTableSqlGenerator());
    }
