    var names = new List<string>();
    using (SqlCommand sqlCommand = new SqlCommand("SELECT [Name] FROM [Persons].[dbo].[Test]", sqlConnection))
    {
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            names.Add(reader[0]);
        }
    }
