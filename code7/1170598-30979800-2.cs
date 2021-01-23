    /// <summary>
    ///     Runs after upgrading to the latest migration to allow seed data to be updated.
    /// </summary>
    /// <param name="context">Context to be used for updating seed data.</param>
    protected override void Seed(AppServerSettingsDataContext context)
    {
        // Creates the Member and assign all the settings which are required for the application to function.
        context.Members.AddOrUpdate(x => x.Name, new Member("Povlo")
        {
            Settings = new List<MemberSettings>
            {
                new MemberSettings("DatabaseConnectionString", "Removed for Security Reasons"),
            }
        });
        // Make sure that for every member, the database is created by using the "MigrateDatabaseToLatestVersion" migration.
        foreach (var setting in context.Members.Select(member => member.Settings.FirstOrDefault(x => x.Key == "DatabaseConnectionString")))
        {
            using (var appServerContext = new AppServerDataContext(setting.Value))
            {
                var de = new MigrateDatabaseToLatestVersion<AppServerDataContext, AppServer.Configuration>();
                de.InitializeDatabase(appServerContext);
                appServerContext.Database.Initialize(true);
            }
        }
    }
