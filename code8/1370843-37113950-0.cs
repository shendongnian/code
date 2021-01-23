	   private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			double selected = Convert.ToDouble(ComboBox1.SelectedItem);
			dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
			SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
			DataTable table = new DataTable();        
			dataAdapter.Fill(table);
			
			foreach(DataRow row in table.Rows)
			{
				var price = Convert.ToDouble(row["price"]);
				var calculation = //do your calculation here with **price** and **selected** value above from combo box
				row["price"] = calculation.ToString();
			}
		    
            datagridview.Source = table;
		}
	
	
