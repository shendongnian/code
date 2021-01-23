    int tableCount = 2; // Or however many tables you want.
    for (int tableIndex = 0; tableIndex < tableCount; tableIndex++)
    {
    	Table tb = new Table();
    	tb.ID = "tbl" + TBname;
    	TableRow rowNew = new TableRow();
    	tb.Controls.Add(rowNew);
    	for (int j = 0; j < cols; j++)
    	{
    		TableCell cellNew = new TableCell();
    		Label lblNew = new Label();
    		rowNew.Controls.Add(cellNew);
    	}
    }
