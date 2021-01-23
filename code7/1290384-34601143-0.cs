	// Add columns to the dataGridView
	dataGridView1.Columns.Add("player_ID", "player_ID");
	dataGridView1.Columns.Add("player_name", "player_name");
	dataGridView1.Columns.Add("player_nick", "player_nick");
	dataGridView1.Columns.Add("HP", "HP");
	// Add some data to the dataGridView
	object[] rowData = new object[dataGridView1.Columns.Count];
	rowData[0] = 0;     // Player_ID
	rowData[1] = "Pancho";        // Player_Name
	rowData[2] = "Speedy";        // Player Nick
	rowData[3] = Convert.ToDecimal("58.7");     // HP
	dataGridView1.Rows.Add(rowData);
	rowData[0] = 1;
	rowData[1] = "Ramon";
	rowData[2] = "Sleepy";
	rowData[3] = Convert.ToDecimal("39.6");     // HP
	dataGridView1.Rows.Add(rowData);
	rowData[0] = 2;
	rowData[1] = "Cimitrio";
	rowData[2] = "Grumpy";
	rowData[3] = Convert.ToDecimal("41.2");     // HP
	dataGridView1.Rows.Add(rowData);
	rowData[0] = 3;                 // Player_ID
	rowData[1] = "Panfilo";         // Player_Name
	rowData[2] = "Gummy Bear";        // Player Nick
	rowData[3] = Convert.ToDecimal("61.5");     // HP
	dataGridView1.Rows.Add(rowData);
	// Sort dataGridView by HP
	dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Ascending);
	// Add rank column            
	dataGridView1.Columns.Add("Rank", "Rank");
	// Rank players
	for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
	{
		dataGridView1.Rows[i].Cells["Rank"].Value = Convert.ToString(i+1);
	}
