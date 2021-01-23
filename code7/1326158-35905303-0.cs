    @using MyLogger;
    @{
        Logger.Initialize(LogLevel.Info, Context.Server.MapPath("~/App_Data/log.txt"));
        WebSecurity.InitializeDatabaseConnection("PhotoGallery", "UserProfiles", "UserId", "Email", true);
    }
