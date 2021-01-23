    bool RestoreDB(string name)
    {
        try
        {
            var connection = ServerConnection(Properties.Settings.Default.Well);
            var sqlServer = new Server(connection);
            var rstDatabase = new Restore();
    
            rstDatabase.Database = name;
            rstDatabase.Action = RestoreActionType.Database;
            rstDatabase.Devices.AddDevice(System.Environment.CurrentDirectory + "\\GC.bak", DeviceType.File);
            rstDatabase.ReplaceDatabase = true;
    
            foreach (DataRow r in rstDatabase.ReadFileList(sqlServer).Rows)
            {
                var relocateFile = new RelocateFile();
    
                relocateFile.LogicalFileName = r["LogicalName"].ToString();
    
                // move/rename physical filename by prepending database name to prevent FileSystem conflicts
                var physicalName = r["PhysicalName"].ToString();
                var path = System.IO.Path.GetDirectoryName(physicalName);
                var filename = System.IO.Path.GetFileName(physicalName);
                physicalName = System.IO.Path.Combine(path, string.Format("{0}_{1}", name, filename));
    
                relocateFile.PhysicalFileName = physicalName;
    
                rstDatabase.RelocateFiles.Add(relocateFile);
            }
    
            rstDatabase.SqlRestore(sqlServer);
    
            connection.Disconnect();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("A problem occured when building the branch!" + ex, "Monytron Consolidator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
