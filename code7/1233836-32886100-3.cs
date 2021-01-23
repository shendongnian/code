    conn.Open();
    NpgsqlTransaction tran = conn.BeginTransaction();
    
    NpgsqlCommand command = new NpgsqlCommand("show_cities", conn);
    command.CommandType = CommandType.StoredProcedure;
    command.ExecuteNonQuery();
    
    command.CommandText = "fetch all in \"<unnamed portal 1>\"";
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
