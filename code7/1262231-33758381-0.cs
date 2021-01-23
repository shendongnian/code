    using (SqlCommand cmd = new SqlCommand("spGetSomeStuff", connection))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        // Optionally, add parameters
        // cmd.Parameters.Add(...);
        // Execute the SP
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            ...
        }
    }
