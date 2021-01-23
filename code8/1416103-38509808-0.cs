    public void Insert(Word word)
    {
        string language=FindLanguage();
        
        using (var connection = new OleDbConnection("connection string goes here"))
        using (var command = new OleDbCommand...)
        {
            command.CommandText = @
                "INSERT INTO " + language + "(Native, Foreign, Definition, AddingDate)" +
                "SELECT '"
                    + word.Native + "' AS Native, '" 
                    + word.Foreign + "' AS Foreign, '" 
                    + word.Definition + "' AS Definition, '"
                    + word.AddingDate + "' AS AddingDate"
            ;
            connection.Close();
        }
    }
