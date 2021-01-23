    using(var con = new SqlConnection(_connectionString))
    {
        con.Open();
        using(var cmd = new SqlCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = "selectMusician";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", recordId);
            ...
        }
    }
