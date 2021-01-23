                ServerConnection con = new ServerConnection(@"ServerName");
                Server server = new Server(con);
                Backup source = new Backup();
                source.Action = BackupActionType.Database;
                source.Database = "DBName";
                BackupDeviceItem destination = new BackupDeviceItem(@"C:\tmp\temp.bak", DeviceType.File);
                source.Devices.Add(destination);
                source.SqlBackup(server);
                con.Disconnect();
