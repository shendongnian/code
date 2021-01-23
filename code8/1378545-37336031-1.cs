	using (var command1 = new SqlCommand("InsertData", conn)
    {
        CommandType = CommandType.StoredProcedure
    })
    {
        command1.Parameters.Add("@a1", SqlDbType.Text).Value = A1;
		command1.Parameters.Add("@a2", SqlDbType.Text).Value = A2;
		command1.Parameters.Add("@a3", SqlDbType.Text).Value = A3;
		command1.Parameters.Add("@a4", SqlDbType.Text).Value = A4;
                                           
        command1.ExecuteNonQuery();
    }
