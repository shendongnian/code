    using Microsoft.SqlServer.Management;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Smo.Agent;
    using Microsoft.SqlServer.Management.Smo.Broker;
    using Microsoft.SqlServer.Management.Smo.Mail;
    using Microsoft.SqlServer.Management.Smo.RegisteredServers;
    using Microsoft.SqlServer.Management.Sdk.Sfc;
    using Microsoft.SqlServer.Management.Common;
 
    protected void btnDatabaseRestore_Click(object sender, EventArgs e)
                {
                    try
                    {
        
                        string fileName = fileBrowsingForBackup.FileName; // Browse The Backup File From Device                
        
                        string restorePath = string.Empty, userName = string.Empty, password = string.Empty, serverName = string.Empty, databaseName = string.Empty;
                        string backFileName = string.Empty, dataFilePath = string.Empty, logFilePath = string.Empty;
        
                        databaseName = "innboard20151215020030";// For Example Restore File Name innboard20151215020030.bak
        
                        restorePath = Server.MapPath(@"~/DatabaseBackup/"); // I used the folder for Restore The Database
        
                        dataFilePath = restorePath;
                        logFilePath = restorePath;
                        restorePath += databaseName + ".bak"; // Get the Backup File Path
        
                        databaseName = "innboard20151215020031"; // I want to Restore The Database name as "innboard20151215020031"
        
    //Get The Database Server Name, UserId, Passsword
    
                        string encryptedConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["InnboardConnectionString"].ConnectionString;
                        string decryptedConnectionString = Cryptography.Decrypt(encryptedConnectionString);
        
                        string[] wordConnectionString = decryptedConnectionString.Split(';');
        
                        string mInitialCatalog = wordConnectionString[0];
                        string mDataSource = wordConnectionString[1];
                        string mUserId = wordConnectionString[2];
                        string mPassword = wordConnectionString[3];
        
                        string mInitialCatalogValue = mInitialCatalog.Split('=')[1];
                        string mDataSourceValue = mDataSource.Split('=')[1];
                        string mUserIdValue = mUserId.Split('=')[1];
                        string mPasswordValue = mPassword.Split('=')[1];
        
                        userName = mUserIdValue;
                        password = mPasswordValue;
                        serverName = mDataSourceValue;
                        
                        // Call The Database Restore Method
                        RestoreDatabase(databaseName, restorePath, serverName, userName, password, dataFilePath, logFilePath);
        
                        CommonHelper.AlertInfo(innboardMessage, "Restore Database Succeed.", "success");
                    }
                    catch (Exception ex)
                    {
                        CommonHelper.AlertInfo(innboardMessage, ex.InnerException.ToString(), "error");
                    }
                }
    
    // Database Restore Method
     
        public void RestoreDatabase(String databaseName, String filePath, String serverName, String userName, String password, String dataFilePath, String logFilePath)
                {
                    try
                    {
    //Action Type
                        Restore sqlRestore = new Restore();
        
                        BackupDeviceItem deviceItem = new BackupDeviceItem(filePath, DeviceType.File);
                        sqlRestore.Devices.Add(deviceItem);
                        sqlRestore.Database = databaseName;
        
                        ServerConnection connection = new ServerConnection(serverName, userName, password);
                        Server sqlServer = new Server(connection);
        
                        Database db = sqlServer.Databases[databaseName];
                        sqlRestore.Action = RestoreActionType.Database;
    
    //Create The Restore Database Ldf & Mdf file name
                        String dataFileLocation = dataFilePath + databaseName + ".mdf";
                        String logFileLocation = logFilePath + databaseName + "_Log.ldf";
                        db = sqlServer.Databases[databaseName];
                        RelocateFile rf = new RelocateFile(databaseName, dataFileLocation);
        
    // Replace ldf, mdf file name of selected Backup file (in that case innboard20151215020030.bak)
                        System.Data.DataTable logicalRestoreFiles = sqlRestore.ReadFileList(sqlServer);
                        sqlRestore.RelocateFiles.Add(new RelocateFile(logicalRestoreFiles.Rows[0][0].ToString(), dataFileLocation));
                        sqlRestore.RelocateFiles.Add(new RelocateFile(logicalRestoreFiles.Rows[1][0].ToString(), logFileLocation));
        
                        sqlRestore.ReplaceDatabase = true;
        
                        sqlRestore.SqlRestore(sqlServer);
                        db = sqlServer.Databases[databaseName];
                        db.SetOnline();
                        sqlServer.Refresh();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
