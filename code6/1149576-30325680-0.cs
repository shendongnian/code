    using(var db = new OleDbConnection(str))
    using(var dbc = db.CreateCommand)
    {
        // Set your CommandText.
        // Add your parameter value.
    
        using(var read = dbc.ExecuteReader())
        {
           //
        }
    }
