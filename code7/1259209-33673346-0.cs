    namespace RMC.Areas.TimeSheet.DAL
    {
        public class timeSheetContext : DbContext
        {
            /* Used from Package Manager Console during manual Migrations */
            public timeSheetContext()
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<timeSheetContext, RMC.Areas.TimeSheet.Migrations.Configuration>(true));
            }
    
            /* Used by App. Must pass the application name every time !*/
            public timeSheetContext(string applicationName)
                : base("name=DBConn_Data." + applicationName + ".FLAT")
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<timeSheetContext, RMC.Areas.TimeSheet.Migrations.Configuration>(true));
            }
