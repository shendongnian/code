    using(var cmd = new SqlCommand())
    {
        using(var con = new SqlConnection(ConnectionString))
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "selectMusician";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", recordId);
            ...
        }
    }
