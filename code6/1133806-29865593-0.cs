	for (int i = 0; i < list.Count; i++)
	{
    	string sql = "SELECT Distinct [Task Name] FROM Tasks WHERE Priority = " + Convert.ToInt32(list[i].GetValue(0));
    	using (OleDbCommand cmd = new OleDbCommand(sql, conn))
        using (OleDbDataReader dataReader = cmd.ExecuteReader())
        {
      		while (dataReader.Read())  
      			taskList.Items.Add((string) dataReader[0]); 
        }
    }
