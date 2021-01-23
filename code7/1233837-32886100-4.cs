    conn.Open();
    NpgsqlTransaction tran = conn.BeginTransaction();
    
    NpgsqlCommand command = new NpgsqlCommand("select show_cities(@ref)", conn);
    command.CommandType = CommandType.Text;
    NpgsqlParameter p = new NpgsqlParameter();
    p.ParameterName = "@ref";
    p.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Refcursor;
    p.Direction = ParameterDirection.InputOutput;
    p.Value = "ref";
    command.Parameters.Add(p);
    command.ExecuteNonQuery();
    
    command.CommandText = "fetch all in \"ref\"";
    command.CommandType = CommandType.Text;
    
    NpgsqlDataReader dr = command.ExecuteReader();
    while (dr.Read())
    {
    	// do what you want with data, convert this to json or...
    	Console.WriteLine(dr[0]);
    }
    dr.Close();
    
    tran.Commit();
    conn.Close();
