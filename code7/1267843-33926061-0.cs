    label1.Text = "";
    
    StringBuilder excelContent = new StringBuilder();
    
    for ( j = 1; j <=last_row; j++)
    {
    	for ( i = 1; i <= last_column; i++)
    	{
    		if (xlws.Cells[j,i].value != null)
    		{
    			excelContent.Append(xlws.Cells[j, i].value.ToString());
    		}
    	}
    	excelContent.Append("\n");
    }
    
    label1.Text = excelContent.ToString();
