    using (var myConnection = new OleDbConnection(myConnectionString))
    using (var myCommand = myConnection.CreateCommand())
    {
        var nameParam = new OleDbParameter("@name", txtname.Text);
    
        myCommand.CommandText = "DELETE FROM [student table] WHERE (Name) = @name";
        myCommand.Parameters.Add(nameParam);
    
        myConnection.Open();
        myCommand.ExecuteNonQuery();
    }
