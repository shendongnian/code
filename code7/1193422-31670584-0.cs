    using(var connection = new SqlConnection(connectionString))
    using(var create = connection.CreateCommand())
    {
         create.CommandText = "...";
         connection.Open();
         create.ExecuteNonQuery();
    }
