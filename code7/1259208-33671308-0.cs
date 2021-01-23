    public timeSheetContext()
            : base("name=DBConn_Data." + Settings.AppName + ".FLAT")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<timeSheetContext, RMC.Areas.TimeSheet.Migrations.Configuration>(true));
        }
