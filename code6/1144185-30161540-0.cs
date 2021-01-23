    DataTable t1;
    DataTable t2;
    
    foreach( DataColumn c in t1.Columns)
    {			
    	if(!t2.Columns.Contains(c.ColumnName))
    	{
    		t2.Columns.Add(new DataColumn(c.ColumnName,c.DataType));
    	}
    }
