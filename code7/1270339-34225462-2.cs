    DbConnectionInfo connectionStringInfo = new DbConnectionInfo(
        "Server=.;Database=MigrationTest;User=sa;Password=dacambiare", "System.Data.SqlClient"); // We shoud retrieve this from App.config
            
    ToolingFacade toolingFacade =  new ToolingFacade(
        "MyDll",   // MigrationAssemblyName. In this case dll should be located in "C:\\Temp\\MigrationTest" dir
        "MyDll",  // ContextAssemblyName. Same as above
        null,
        "C:\\Temp\\MigrationTest",   // Where the dlls are located
        "C:\\Temp\\MigrationTest\\App.config", // Insert the right directory and change with Web.config if required
        "C:\\Temp\\App_Data",
        connectionStringInfo)
    {
        LogInfoDelegate = s => {Console.WriteLine(s);},
        LogWarningDelegate = s => { Console.WriteLine("WARNING: " + s); },
        LogVerboseDelegate = s => { Console.WriteLine("VERBOSE: " + s); }
    };
            
    ScaffoldedMigration scaffoldedMigration = toolingFacade.Scaffold("MyMigName", "C#", "MyAppNameSpace", false);
    Console.WriteLine(scaffoldedMigration.DesignerCode);
    Console.WriteLine("==================");
    Console.WriteLine(scaffoldedMigration.UserCode);
    // Don't forget the resource file that is in the scaffoldedMigration
