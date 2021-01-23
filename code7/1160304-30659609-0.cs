     private static void SeedMasterData ( IpDataContext context, string databaseName)
    {
      context.Database.CreateIfNotExists();
      var sqlContent = Content(IndexScriptSeedMasterDataLocation);
      var modifiedSqlScript = sqlContent.Replace("@DatabaseName", databaseName);
      context.Database.ExecuteSqlCommand(modifiedSqlScript);
    }
