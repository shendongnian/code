    var names = new List<string>();
    using (SqlCommand sqlCommand = new SqlCommand("SELECT [Name] FROM [Persons].[dbo].[Test]", sqlConnection))
    {
        using(var reader = sqlCommand.ExecuteReader())
        {
           while(reader.Read())
           {
              names.Add(reader["Name"].ToString());
           }
        }
    }
