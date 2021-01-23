	// your OleDbConnection should also be wrapped in a using statement to ensure it is closed
	using(OleDbCommand cmd = new OleDbCommand("UPDATE Data SET Title = ? WHERE ID = ?")) // wrap in using block because OleDbCommand implements IDisposable
	{
		// also open the connection if it is not already open
		// conn.Open();
		cmd.CommandType = CommandType.Text;
		cmd.Connection = conn;
		cmd.Parameters.AddWithValue("?", TextBox1.Text); // Title
		cmd.Parameters.AddWithValue("?", param2); // ID
		cmd.ExecuteNonQuery(); // execute the query
	}
