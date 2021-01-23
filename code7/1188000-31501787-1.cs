    public void Restore(OdbcConnection sqlcon, string DatabaseFullPath, string backUpPath)
        {    
                using (sqlcon)
                { 
                    string UseMaster = "USE master";
                    OdbcCommand UseMasterCommand = new OdbcCommand(UseMaster, sqlcon);
                    UseMasterCommand.ExecuteNonQuery();
                    // The below query will rollback any transaction which is 
                    // running on that database and brings SQL Server database
                    // in a single user mode.
                    string Alter1 = @"ALTER DATABASE 
                    [" + DatabaseFullPath + "] SET Single_User WITH Rollback Immediate";
                    OdbcCommand Alter1Cmd = new OdbcCommand(Alter1, sqlcon);
                    Alter1Cmd.ExecuteNonQuery();
                    // The below query will restore database file from disk 
                    // where backup was taken ....
                    string Restore = @"RESTORE DATABASE 
                    [" + DatabaseFullPath + "] FROM DISK = N'" + 
                    backUpPath + @"' WITH  FILE = 1,  NOUNLOAD,  STATS = 10";
                    OdbcCommand RestoreCmd = new OdbcCommand(Restore, sqlcon);
                    RestoreCmd.ExecuteNonQuery();
                    // the below query change the database back to multiuser
                    string Alter2 = @"ALTER DATABASE 
                    [" + DatabaseFullPath + "] SET Multi_User";
                    OdbcCommand Alter2Cmd = new OdbcCommand(Alter2, sqlcon);
                    Alter2Cmd.ExecuteNonQuery();
                    Cursor.Current = Cursors.Default;
                }
             } 
