    public static void BackupDatabase(string backUpFile)
        {
        ServerConnection con = new ServerConnection(@"xxxxx\SQLEXPRESS");
        Server server = new Server(con);
        Backup source = new Backup();
        source.Action = BackupActionType.Database;
        source.Database = "MyDataBaseName";
        BackupDeviceItem destination = new BackupDeviceItem(backUpFile, DeviceType.File);
        source.Devices.Add(destination);
        source.SqlBackup(server);
        con.Disconnect();
        }
    
    public static void RestoreDatabase(string backUpFile)
        {
        ServerConnection con = new ServerConnection(@"xxxxx\SQLEXPRESS");
        Server server = new Server(con);
        Restore destination = new Restore();
        destination.Action = RestoreActionType.Database;
        destination.Database = "MyDataBaseName";
        BackupDeviceItem source = new BackupDeviceItem(backUpFile, DeviceType.File);
        destination.Devices.Add(source);
        destination.ReplaceDatabase = true;
        destination.SqlRestore(server);
        }
