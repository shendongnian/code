    Public string GetConnectionString()
    {
        //Read the Application Settings from App.Config 
        SqlConnectionStringBuilder sqlConstrBuilder = new SqlConnectionStringBuilder();
        sqlConstrBuilder.DataSource = dataSource;
        sqlConstrBuilder.InitialCatalog = databaseName;
        sqlConstrBuilder.UserID = ConfigurationManager.AppSettings["UserId"].ToString();
        sqlConstrBuilder.Password = ConfigurationManager.AppSettings["Password"].ToString();
    
        return sqlConstrBuilder.ConnectionString;
    }
