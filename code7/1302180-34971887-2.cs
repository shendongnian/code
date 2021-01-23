    public void MultipleResultSets()
    {
        var db = new DbContext();
        var command = db.Database.Connection.CreateCommand();
        command.Connection.Open();
        command.CommandText =
            @"
            SELECT * FROM TableA; 
            SELECT * FROM TableB;
            ";
    
        using (var reader = command.ExecuteReader())
        {
            // Map Table A rows
            var tableARows = db.MapReader<TableA>(reader);
            reader.NextResult();
    
            // Map Table B rows
            var tableBRows = db.MapReader<TableB>(reader);
        }
        command.Connection.Close();
    }
