    public void Addtable(HtmlTable baseTable, int j)
    {
    
    	HtmlTable innerTable = new HtmlTable();
    	baseTable.Controls.Add(innerTable);
    	HtmlTableRow row = new HtmlTableRow();
    	HtmlTableCell cell = new HtmlTableCell();
    	cell.InnerText = "col 1";
    	row.Cells.Add(cell);
    
    	cell = new HtmlTableCell();
    	cell.InnerText = "col2";
    	row.Cells.Add(cell);
    
    	innerTable.Rows.Add(row);
    
    	innerTable.Border = 1;
    
    	if (j < 5)
    	{
    		j++;
    		Addtable(innerTable, j);
    
    	}
    }
