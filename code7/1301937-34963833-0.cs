     public class DownloadDatabase
    {
        SQLiteConnection sqliteConnection;
        public DownloadDatabase(string dbName)
        {
            string ConnectionString = "Data Source=" + "Absoute path to database store location" + ";Version=3;";
            sqliteConnection = new SQLiteConnection(ConnectionString);
            sqliteConnection.Open();
        }
        
        public void CreateDB()
        {
            string table = "CREATE TABLE IF NOT EXISTS Downloads ( _id INTEGER  PRIMARY KEY NULL,user_id TEXT  NULL DEFAULT '', target_id TEXT NOT NULL, url TEXT NOT NULL, local_file TEXT NOT NULL,authenticate TEXT NOT NULL DEFAULT '', login TEXT NULL DEFAULT '', password TEXT NULL DEFAULT '', mime_type TEXT NULL DEFAULT '', accept_ranges TEXT NULL DEFAULT '', file_size NUMBER NULL DEFAULT 0, last_modified TEXT NULL DEFAULT '',created TEXT NULL DEFAULT '',initial_start_position NUMBER NULL DEFAULT 0, start_position NUMBER NULL DEFAULT 0, end_position NUMBER NULL DEFAULT 0, progress TEXT NOT NULL,is_paused TEXT NULL ,device_id TEXT NULL, state NUMBER NULL, originID TEXT NULL DEFAULT '');";
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(table, sqliteConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Creating Downloads database failed: " + ex.Message);
            }
        }
      
        public void UpdateDBAndCreateEntryIfNotExists(DownloadItem item)
        {
            try
            {
                using (SQLiteCommand checkEntryCommand = sqliteConnection.CreateCommand())
                {
                    checkEntryCommand.CommandText = "SELECT * FROM Downloads WHERE target_id=@target_id LIMIT 1";
                    checkEntryCommand.Parameters.Add(new SQLiteParameter("@target_id", item.targetID));
                    using (SQLiteDataReader reader = checkEntryCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            using (SQLiteCommand updatecommand = sqliteConnection.CreateCommand())
                            {
                                double dprogress;
                                if (!Double.TryParse(reader.GetString(16), out dprogress))
                                {
                                    dprogress = 0;
                                }
                                if (item.progress != dprogress)
                                {
                                    updatecommand.CommandText = "UPDATE Downloads SET last_modified=@last_modified, start_position=@start_position, end_position=@end_position, progress = @progress, is_paused = @is_paused, state = @state WHERE target_id=@target_id";
                                    updatecommand.Parameters.Add(new SQLiteParameter("@last_modified", item.lastModified));
                                    updatecommand.Parameters.Add(new SQLiteParameter("@start_position", item.startPosition));
                                    updatecommand.Parameters.Add(new SQLiteParameter("@end_position", item.endPosition));
                                    updatecommand.Parameters.Add(new SQLiteParameter("@progress", item.progress));
                                    updatecommand.Parameters.Add(new SQLiteParameter("@target_id", item.targetID));
                                    updatecommand.Parameters.Add(new SQLiteParameter("@is_paused", item.isPaused ? "True" : "False"));
                                    updatecommand.Parameters.Add(new SQLiteParameter("@state", item.state));
                                    updatecommand.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            using (SQLiteCommand insertcommand = sqliteConnection.CreateCommand())
                            {
                                insertcommand.CommandText = "INSERT INTO Downloads ( target_id, url,local_file, authenticate, login, password, mime_type, accept_ranges, file_size, last_modified, created, initial_start_position, start_position, end_position, progress, is_paused, device_id, state, originID)  values (@target_id,@url, @local_file, @authenticate,@login,@password,@mime_type,@accept_ranges,@file_size, @last_modified,@created, @initial_start_position,@start_position,@end_position,@progress,@is_paused, @device_id, @state, @originID) ";
                                insertcommand.Parameters.Add(new SQLiteParameter("@target_id", item.targetID));
                                insertcommand.Parameters.Add(new SQLiteParameter("@url", item.url));
                                insertcommand.Parameters.Add(new SQLiteParameter("@local_file", item.localFile));
                                insertcommand.Parameters.Add(new SQLiteParameter("@authenticate", item.authenticate));
                                insertcommand.Parameters.Add(new SQLiteParameter("@login", item.login == null ? "" : item.login));
                                insertcommand.Parameters.Add(new SQLiteParameter("@password", item.password == null ? "" : item.password));
                                insertcommand.Parameters.Add(new SQLiteParameter("@mime_type", item.mimeType));
                                insertcommand.Parameters.Add(new SQLiteParameter("@accept_ranges", item.acceptRanges));
                                insertcommand.Parameters.Add(new SQLiteParameter("@file_size", item.fileSize));
                                insertcommand.Parameters.Add(new SQLiteParameter("@last_modified", item.lastModified));
                                insertcommand.Parameters.Add(new SQLiteParameter("@created", item.created));
                                insertcommand.Parameters.Add(new SQLiteParameter("@initial_start_position", item.initialStartPosition));
                                insertcommand.Parameters.Add(new SQLiteParameter("@start_position", item.startPosition));
                                insertcommand.Parameters.Add(new SQLiteParameter("@end_position", item.endPosition));
                                insertcommand.Parameters.Add(new SQLiteParameter("@progress", item.progress));
                                insertcommand.Parameters.Add(new SQLiteParameter("@is_paused", item.isPaused ? "True" : "False"));
                                insertcommand.Parameters.Add(new SQLiteParameter("@device_id", item.deviceId == null ? "" : item.deviceId));
                                insertcommand.Parameters.Add(new SQLiteParameter("@state", item.state));
                                insertcommand.Parameters.Add(new SQLiteParameter("@originID", item.originID));
                                insertcommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Download progress update failed: " + ex.Message);
            }
        }
       
        public bool DeleteItem(string targetID)
        {
            try
            {
                using (SQLiteCommand deleteCommand = sqliteConnection.CreateCommand())
                {
                    string tableName = "";
                    tableName = "Downloads";
                    deleteCommand.CommandText = "DELETE FROM " + tableName + " WHERE target_id=@target_id";
                    deleteCommand.Parameters.Add(new SQLiteParameter("@target_id", targetID));
                    deleteCommand.ExecuteReader();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete item Failed: " + ex.Message);
                return false;
            }
        }
    }
 
