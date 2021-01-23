    public static void RestoreDatabase(string Server_Name, string Instance_Name, string DB_Name,
                                       FileInfo BakFile, FileInfo DiffFile, FileInfo TrnFile, DateTime Point_In_Time)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Data Source=" + Server_Name + "\\" + Instance_Name + ";Initial Catalog=master;Integrated Security=True";
        string SqlQuery = string.Format(@"DECLARE @strSQL NVARCHAR(MAX) =''
										SELECT
                                        @strSQL +=  N'ALTER DATABASE ' + QUOTENAME(@dbName)
                                         + N' SET SINGLE_USER'
                                         + N' WITH ROLLBACK IMMEDIATE;'
                                         + N' RESTORE DATABASE ' + QUOTENAME(@dbName) 
                                         + N' FROM DISK = N''' + @BakFilePath + ''''
                                         + N' WITH NORECOVERY, REPLACE;'
                                         + N' RESTORE DATABASE ' + QUOTENAME(@dbName)  + 
                                         + N' FROM DISK = N''' + @DiffFilePath + ''''
                                         + N' WITH NORECOVERY;'  
                                         + N' RESTORE DATABASE ' + QUOTENAME(@dbName) 
                                         + N' FROM DISK = N''' + @TrnFilePath + ''''
                                         + N' WITH NORECOVERY, STOPAT =  N''' + @RecoveryTime + ''';'
                                         + N' RESTORE DATABASE ' + QUOTENAME(@dbName)
                                         + N' WITH RECOVERY;'
                                         + N' ALTER DATABASE ' + QUOTENAME(@dbName)
                                         + N' SET MULTI_USER;
                                        ' 
                                         EXEC sp_executesql @strSQL");
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection = conn;
        cmd.CommandText = SqlQuery;
        try
        {
            cmd.Parameters.Add(new SqlParameter("@dbName", SqlDbType.NVarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@BakFilePath", SqlDbType.NVarChar, 255));
            cmd.Parameters.Add(new SqlParameter("@DiffFilePath", SqlDbType.NVarChar, 255));
            cmd.Parameters.Add(new SqlParameter("@TrnFilePath", SqlDbType.NVarChar, 255));
            cmd.Parameters.Add(new SqlParameter("@RecoveryTime", SqlDbType.NVarChar,30));
            cmd.Parameters["@dbName"].Value = DB_Name;
            cmd.Parameters["@BakFilePath"].Value = BakFile.FullName;
            cmd.Parameters["@DiffFilePath"].Value = DiffFile.FullName;
            cmd.Parameters["@TrnFilePath"].Value = TrnFile.FullName;
            cmd.Parameters["@RecoveryTime"].Value = Point_In_Time.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
        try
        {
            Console.WriteLine("Restoring {0}...", DB_Name);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Console.WriteLine("Restore Complete!");
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Connection could not open. Error: {0}", ex);
            Console.ReadLine();
        }
    }
