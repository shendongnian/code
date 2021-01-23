    bool hasCellBeenEdited = false;
    
    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
    	// Set flag that cell has been edited
    	hasCellBeenEdited = true;
    }
    
    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
    	// If edit flag is set and it's not already the last last column, move to the next column
    	if (hasCellBeenEdited && dataGridView1.CurrentCell.ColumnIndex != dataGridView1.ColumnCount - 1)
    	{
    		int desiredColumn = dataGridView1.CurrentCell.ColumnIndex + 1;
    		int desiredRow = dataGridView1.CurrentCell.RowIndex - 1;
    
    		dataGridView1.CurrentCell = dataGridView1[desiredColumn, desiredRow];
    		hasCellBeenEdited = false;
    	}
    	
        // If edit flag is set and it is the last column, go back to the first column
    	else if (hasCellBeenEdited && dataGridView1.CurrentCell.ColumnIndex == dataGridView1.ColumnCount - 1)
    	{
    		int desiredColumn = 0;
    		int desiredRow = dataGridView1.CurrentCell.RowIndex - 1;
    
    		dataGridView1.CurrentCell = dataGridView1[desiredColumn, desiredRow];
    		hasCellBeenEdited = false;
    	}
    }
