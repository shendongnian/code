    private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
    	if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "status" && e.Value is string)
    	{
    		string text = (string)e.Value;
    
    		if (text == "PAUSE")
    		{// Change the color
    			e.CellStyle.BackColor = Color.Red;
    			e.CellStyle.ForeColor = Color.Blue;
    		}
    	}
    }
