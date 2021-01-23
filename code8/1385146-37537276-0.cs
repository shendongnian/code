    using (var command = new SqlCommand("[stored procedure name]", connection))
    {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@Parameter1", SqlDbType).Value = Value1;
        // other parameters here
    
        command.ExecuteNonQuery(); // or ExecuteReader
    }
