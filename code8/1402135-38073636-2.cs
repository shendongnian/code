	// your OleDbConnection should also be wrapped in a using statement to ensure it is closed
	using (OleDbConnection conn = new OleDbConnection(connectionString))
	{
		conn.Open(); // open the connection
		using(OleDbCommand cmd = new OleDbCommand("UPDATE Data SET Title = ? WHERE ID = ?")) // wrap in using block because OleDbCommand implements IDisposable
		{
			cmd.CommandType = CommandType.Text;
			cmd.Connection = conn;
			cmd.Parameters.AddWithValue("Title", TextBox1.Text).OleDbType = OleDbType.VarChar; // Title, also set the parameter type
			cmd.Parameters.AddWithValue("ID", param2).OleDbType = OleDbType.Integer; // ID, I am guessing its an integer but you should replace it with the correct OleDbType
			var recordsUpdated = cmd.ExecuteNonQuery(); // execute the query
			// recordsUpdated contains the number of records that were affected
		}
	}
