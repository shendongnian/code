    using (var dbCommand = new SqlCommand("INSERT INTO Foo (id, name) VALUES (@id, @name)", dbConn))
    {
        dbCommand.Parameters.Add("id", SqlType.Integer).Value = 42;
        dbCommand.Parameters.Add("name", SqlType.VarChar).Value = "Bar";
        dbCommand.ExecuteNonQuery();
    }
