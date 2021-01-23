	void GetEmployee(int employeeID)
	{
		// 1
		// Open connection
		using (SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.DataConnectionString))
		{
			sqlConnection.Open();
			// 2
			// Create new DataAdapter
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("EXEC dbo.spSelectEmployee " + employeeID, sqlConnection))
			{
				// 3
				// Use DataAdapter to fill DataTable
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
			// 4
			// Render data onto the screen
			// dataGridView1.DataSource = dataTable; // <-- From your designer
			}
		}
	}
