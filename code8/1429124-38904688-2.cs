    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
    {
    	objexcelapp.Cells[1, i] = dataGridView1.Columns.Count - 1; i++;
    }
    
    for (int i = 0; i < 3; i++)
    {
    	for (int j = 0; j < dataGridView1.Columns.Count; j++)
    	{
    		if (dataGridView1.Rows[i].Cells[j].Value != null)
    		{
    			objexcelapp.Cells[i + 11, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
    		}
    	}
    
    }
