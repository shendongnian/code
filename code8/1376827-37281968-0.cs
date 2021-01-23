    DataTable tbl = new DataTable();
    for(int i=0;i<numOfColumns;i++)
    {
    	DataColumn column = new DataColumn("Column" + (i+1));
    	tbl.Columns.Add(column);
    }
    
    dg.DataSource  = tbl;
