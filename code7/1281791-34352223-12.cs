	string SelectItem(MySqlConnection conn, string Name)
	{
	
		string result="";
	
		MySqlCommand cmd = new MySqlCommand();
		cmd.Connection = conn;
		cmd.CommandType = CommandType.Text;
		cmd.CommandText = "select color.idcolor from color where color.name = @color.name";
		cmd.Parameters.AddWithValue("@color.name", Name);
	
		conn.Open();
		MySqlDataAdapter da = new MySqlDataAdapter();
		DataTable dt = new DataTable();
		da.SelectCommand = cmd;
		da.Fill(dt);
		
		result=dt.Rows[0].ItemArray[0].ToString();
		
		conn.Close();
	
		return result;
		
	}
