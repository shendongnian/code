    private void WriteToFile()
    {
    	DataTable dataTable = new DataTable();
    
    	//create columns
    	for (int i = 0; i < DG_dataGridView.Columns.Count; i++)
    	{
    		dataTable.Columns.Add("column"+i.ToString());
    	}
    
    	//populate data
    	foreach (GridViewRow row in DG_dataGridView.Rows)
    	{
    		DataRow dr = dataTable.NewRow();
    		for(int j = 0; j < DG_dataGridView.Columns.Count; j++)
    		{
    			dr["column" + j.ToString()] = row.Cells[j].Text;
    		}
    
    		dataTable.Rows.Add(dr);
    	}
    	
    	//write to file
    	string dataFile = "c:\test.xml"
    	dataTable.DataSet.WriteXml(dataFile);
    }
		
