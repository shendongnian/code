    public string GetFirstReadNotes()
    {
        string scriptNotes = string.Empty;
        String dbConnectionString = @"Data Source =DB.sqlite";
    
        SQLiteConnection cnn = new SQLiteConnection(dbConnectionString);
        cnn.Open();
    
        SQLiteCommand cmd = new SQLiteCommand(cnn);
        cmd.CommandText = "SELECT* FROM projects WHERE projectID = 1";
    
        SQLiteDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
        {
             scriptNotes = reader["scriptnotes"].ToString();
        }
        reader.Close();
        cnn.Close();
        }
        return scriptNotes;
    }
