    public static class MyCachedSettings
    {
         public static string ConnectionString = 
         ConfigurationManager.ConnectionStrings["CatalogueConnectionString" ].ConnectionString;
         public static SqlConnection Connection = new SqlConnection(ConnectionString);
    }
