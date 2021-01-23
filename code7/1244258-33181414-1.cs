	public InventoryForm()
	{
	    InitializeComponent();
	    Program.CheckInventoryEvent += Program_CheckInventoryEvent;
	}
	private void Program_CheckInventoryEvent(object sender, EventArgs e)
	{
		try
		{
			connection.Open();
			OleDbCommand command = new OleDbCommand();
			command.Connection = connection;
			string query = "select Item, Quantity from Inventory WHERE Quantity < 15";
			command.CommandText = query;
			// Find low Inventory items and display in dialog
			StringBuilder sb = new StringBuilder();
			OleDbDataReader reader = command.Execute();
			while (reader.Read())
			{
				sb.AppendLine(string.Format("{0} qty: {1}"), reader["Item"].ToString(), reader["Quantity"].ToString());
			}
			connection.Close();
			MessageBox.Show(sb.ToString(), "Low Inventory Items");
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error " + ex);
		}
	}
