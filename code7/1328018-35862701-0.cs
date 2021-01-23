    public static ControllerBaseExtensions
    {
      private const string DBNAME = "DB_NAME";
      public static bool TryGetDatabaseName(this ControllerBase instance,
        out string DbName)
      {
        DbName = null;
        var app = GetApp(instance);
        var result = app.Any(k => k == DBNAME);
        if (result)
        {
          DbName = instance.Application[DBNAME] as string;
          result = DbName != null;
        }
      }
      public static SetDatabaseName(this ControllerBase instance,
        string DbName)
      {
        var app = GetApp(instance);
        app[DBNAME] = DbName;
      }
      private static HttpApplication GetApp(ControllerBase instance)
      {
        return instance.ControllerContext.HttpContext.Application;
      }
    }
    public ActionResult MyMethod()
    {
      string DbName;
      if (!this.TryGetDatabaseName(out DbName))
      {
        FormsAuthentication.SignOut();
        // http://stackoverflow.com/questions/30509980
        RedirectToAction("Login", "Account");
      }
      CreateEntitiesForSpecificDatabaseName(Dbname);
    }
    public static DatabaseNameEntities CreateEntitiesForSpecificDatabaseName(
      string dbName,
      bool contextOwnsConnection = true)
    {
              
      //Initialize the SqlConnectionStringBuilder
              
      //Initialize the EntityConnectionStringBuilder
               
      //Create entity connection
      EntityConnection connection = new
        EntityConnection(entityBuilder.ConnectionString);
    
      return new DatabaseNameEntities(connection);
    }
