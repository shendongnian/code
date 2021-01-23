    using (var conn = new System.Data.SqlClient.SqlConnection(usingConnectionString))
    {
        using (var command = new System.Data.SqlClient.SqlCommand(usingQuery, conn))
        {
            using (var reader = command.ExecuteReader())
            {
                // do your work here...
            }
        }
    }
