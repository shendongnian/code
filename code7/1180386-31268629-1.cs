    using(var connection = new OleDbConnection(conString))
    using(var command = connection.CreateCommand())
    {
        commmand.CommandText = @"INSERT INTO Посещения([patient ID],[doctor ID], [desease ID], [visit date])
                                 VALUES(?, ?, ?, ?)";
        command.Parameters.AddWithValue("patient ID", "1");
        command.Parameters.AddWithValue("doctor ID", "1");
        command.Parameters.AddWithValue("desease ID", "1");
        command.Parameters.AddWithValue("visit date", "01.05.1999");
        adapter.InsertCommand = command;
        connection.Open();
        adapter.InsertCommand.ExecuteNonQuery();
    }
