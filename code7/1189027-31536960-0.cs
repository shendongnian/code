                string connectionString = ConfigurationManager.ConnectionStrings["TESTConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
    
                    string DatabaseName = "TEST";
                    string fileName = "TEST.bak";
    
                    string UseMaster = "USE master";
                    SqlCommand UseMasterCommand = new SqlCommand(UseMaster, con);
                    UseMasterCommand.ExecuteNonQuery();
                    int iReturn = 0;
    
                    // If the database does not exist then create it.
                    string strCommand = string.Format("SET NOCOUNT OFF; SELECT COUNT(*) FROM master.dbo.sysdatabases where name=\'{0}\'", DatabaseName);
                    using (SqlCommand sqlCmd = new SqlCommand(strCommand, con))
                    {
                        iReturn = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    }
                    if (iReturn == 0)
                    {
                        SqlCommand command = con.CreateCommand();
                        command.CommandText = "CREATE DATABASE " + DatabaseName;
                        command.ExecuteNonQuery();
                    }
                    ServerConnection serverConnection = new ServerConnection(con);
                    Microsoft.SqlServer.Management.Smo.Server srv = new Microsoft.SqlServer.Management.Smo.Server(serverConnection);
                    string Alter1 = @"ALTER DATABASE [" + DatabaseName + "] SET Single_User WITH Rollback Immediate";
                    SqlCommand Alter1Cmd = new SqlCommand(Alter1, con);
                    Alter1Cmd.ExecuteNonQuery();
                    string Restore = @"RESTORE Database [" + DatabaseName + "] FROM DISK = N'" + fileName + @"' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10";
                    SqlCommand RestoreCmd = new SqlCommand(Restore, con);
                    RestoreCmd.ExecuteNonQuery();
                    string Alter2 = @"ALTER DATABASE [" + DatabaseName + "] SET Multi_User";
                    SqlCommand Alter2Cmd = new SqlCommand(Alter2, con);
                    Alter2Cmd.ExecuteNonQuery();
                }
