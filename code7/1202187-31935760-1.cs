    using(SqlConnection con = generateConnectionString())
    using(var command = con.CreateCommand())
    {
        command.CommandText = "SELECT_ORDERSTATUS_BY_ORDERDATETIME";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@ORDERDATETIME", SqlDbType.DateTime).Value = odt;
    
        con.Open();
        string status = (string)command.ExecuteScalar();
    }
