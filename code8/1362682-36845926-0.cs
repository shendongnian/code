    //this list should be declared out of this scope and be declared in the main class
    List<YourDbModel> models = new List<YourDbModel>();   
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
        OleDbCommand command = new OleDbCommand(queryString, connection);
        connection.Open();
        OleDbDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            // translate the properties of your query to your model.
            YourDbModel model = new YourDBModel();
            model.property = reader[0].ToString();
            models.add(model);
        }
        reader.Close();
    }   
