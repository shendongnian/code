    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
    	//customized global checkbox  in header
    	int iCheckBoxColumnIndex = 7; // index of check box cell
    	bool bValue = checkBox1.Checked;
    	for (int iRow = 0; iRow < dataGridView1.Rows.Count; iRow++)
    	{
    		if (iRow == dataGridView1.NewRowIndex)
    			continue;
    		dataGridView1.Rows[iRow].Cells[iCheckBoxColumnIndex].Value = bValue;
    		checkValue(iRow, bValue);
    	}
    }
