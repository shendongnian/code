       internal class DataLayer: IFirstReadViewModelDAL
        {
            public string GetFirstReadNotes()
            {
                string ScriptNotes;
                String dbConnectionString = @"Data Source =DB.sqlite";
    
                using(SQLiteConnection cnn = new SQLiteConnection(dbConnectionString))
                {
                    cnn.Open();
    
                    SQLiteCommand cmd = new SQLiteCommand(cnn);
                    cmd.CommandText = "SELECT* FROM projects WHERE projectID = 1";
    
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ScriptNotes = reader["scriptnotes"].ToString();
                        }
                    }
                }
    
                return ScriptNotes;
            }
        }
