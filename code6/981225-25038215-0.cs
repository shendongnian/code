            string backupDB = String.Format(@"{0}\{1}", Constants.Paths.CompressedProjects, Constants.DataBase.FileNameBackup);
            string databaseName = Constants.DataBase.LogicalName; // This is not the MDF file, but the logical database name
            using (var db = new DBContext())
            {
                string[] parms = new string[2];
                parms[0] = databaseName;
                parms[1] = backupDB;
                var cmd = "BACKUP DATABASE " + databaseName + " TO DISK='" + backupDB + "' WITH FORMAT;";
                db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, cmd, parms);
            }
            
