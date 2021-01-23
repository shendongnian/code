    using (var _connection = new SQLitePCL.SQLiteConnection(sqlpath))
    {
        using (var statement = _connection.Prepare("SELECT word, translation FROM " + TABLE_NAME_IND + " WHERE word like '?%'"))
        {
            while (statement.Step() == SQLiteResult.ROW)
            {
                ind_dict Ind = new ind_dict();
                Ind.Word = statement["word"] as String;
                Ind.Translation = statement["translation"] as String;
    
                indDatasource.Add(Ind);
            }
        }
    }
    
    if (indDatasource.Count > 0)
    {
        translation.ItemsSource = indDatasource;
    }
