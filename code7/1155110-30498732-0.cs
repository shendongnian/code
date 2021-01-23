    public MyContext() : base(BuildConnectionString())
    {
    }
    private static string BuildConnectionString()
    {
      varsqlBuilder = new SqlConnectionStringBuilder();
      //dinamically prepare the provider connection string here, using the CF one in the web.config 
      //[..]
      //now build the entity connection string, using the one just built as ProviderConnectionString
      var entityBuilder = new EntityConnectionStringBuilder();
      entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
      entityBuilder.Metadata = "res://*/";
      entityBuilder.Provider = "System.Data.SqlClient";
      return entityBuilder.ToString();
    }
