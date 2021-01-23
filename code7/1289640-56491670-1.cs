    namespace DB_Restore
    {
        class Program
        {
            static void Main(string[] args)
            {
                RestoreDatabase();
            }
            public static void RestoreDatabase()
            {
                try
                {
                    ServerConnection connection = new ServerConnection(@"Server\instance", "uname", "PWD");
                    Server sqlServer = new Server(connection);
                    Restore rstDatabase = new Restore();
                    rstDatabase.Action = RestoreActionType.Database;
                    rstDatabase.Database = "H5MI_Automation_Restore_Backup";
                    BackupDeviceItem bkpDevice = new BackupDeviceItem(@"E:\DATA\QA_SP\MSSQL11.QA_SP\MSSQL\Backup\H5MI_Automation.bak", DeviceType.File);
                    rstDatabase.Devices.Add(bkpDevice);
                    rstDatabase.ReplaceDatabase = true;
                    //As mentioned in the above solution this code will take care .mdf and .ldf file location issue
                    foreach (DataRow r in rstDatabase.ReadFileList(sqlServer).Rows)
                    {
                        var relocateFile = new RelocateFile();
                        relocateFile.LogicalFileName = r["LogicalName"].ToString();
                        Console.WriteLine(relocateFile.LogicalFileName);
                        var physicalName = r["PhysicalName"].ToString();
                        Console.WriteLine(physicalName);
                        var path = System.IO.Path.GetDirectoryName(physicalName);
                        Console.WriteLine(path);
                        var filename = System.IO.Path.GetFileName(physicalName);
                        Console.WriteLine(filename);
                        physicalName = path + @"\H5MI_Automation_Restore_Backup_" + filename;
                        Console.WriteLine(physicalName);
                        relocateFile.PhysicalFileName = physicalName;
                        Console.WriteLine(relocateFile.PhysicalFileName);
                        Console.WriteLine(relocateFile);
                        rstDatabase.RelocateFiles.Add(relocateFile);
                    }
                    rstDatabase.SqlRestore(sqlServer);
                    connection.Disconnect();
                }
                catch (Exception e)
                {
    
                    Console.Write(e);
                }
            }
        }
    }
