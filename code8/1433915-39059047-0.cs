    string db = "MyDB.s3db";
    List<Phrase> phraseList = new List<Phrase>()
    {
        new Phrase() { Keyword = "start", Translation1="Hi!", Translation2="Привет!" },
        new Phrase() { Keyword = "end", Translation1="Bye!", Translation2="Пока!" },
    };
    
    try
    {
        using (var conn = new SQLiteConnection("Data Source=" + db))
        {
            conn.Open();
    
            string createCmd =
                "CREATE TABLE IF NOT EXISTS Phrases (Id INTEGER PRIMARY KEY AUTOINCREMENT, Keyword TEXT, Translation1 TEXT, Translation2 TEXT)";
            using (var cmd = new SQLiteCommand(createCmd, conn))
            {
                cmd.ExecuteNonQuery();
            }
    
            string insertCmd =
                "INSERT INTO Phrases (Keyword, Translation1, Translation2) VALUES(?,?,?)";
            foreach (Phrase phrase in phraseList)
            {
                using (var cmd = new SQLiteCommand(insertCmd, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword",phrase.Keyword);
                    cmd.Parameters.AddWithValue("@Translation1", phrase.Translation1);
                    cmd.Parameters.AddWithValue("@Translation2", phrase.Translation2);
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
        }
    }
    catch (Exception exc)
    {
        Debug.WriteLine(exc.Message);
        Debug.WriteLine(exc.StackTrace);
    }
