    System.AccessViolationException: Attempted to read or write protected memory. This is often an indication that other memory is corrupt. 
    at System.Data.SQLite.UnsafeNativeMethods.sqlite3_open_interop(Byte[] utf8Filename, Int32 flags, IntPtr& db) 
    at System.Data.SQLite.SQLite3.Open(String strFilename, SQLiteConnectionFlags connectionFlags, SQLiteOpenFlagsEnum openFlags, Int32 maxPoolSize, Boolean usePool) 
    at System.Data.SQLite.SQLiteConnection.Open() 
    at STCommonShellIntegration.DataShellManagement.CreateNewConnection(SQLiteConnection& newConnection) 
    at STCommonShellIntegration.DataShellManagement.InitConfiguration(Dictionary`2 targetSettings) 
    at DBROverlayIcon.DBRBackupOverlayIcon.initComponent()
