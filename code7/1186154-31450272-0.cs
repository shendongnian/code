	using (OdbcConnection myConnection = new OdbcConnection(myConnectionString))
	{
		myConnection.Open();
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			String insSQL = "INSERT INTO t1 (column1) VALUES ('" + dataTable.Rows[i].ItemArray.GetValue(0) + "')";
			OdbcCommand command = new OdbcCommand(insSQL, myConnection);
			command.ExecuteNonQuery();
		}
	}
