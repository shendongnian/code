    public void Addtable(HtmlTable baseTable, int j)
    {
    
    	HtmlTable innerTable = new HtmlTable();
    
        HtmlTableRow row = new HtmlTableRow();
    	HtmlTableCell cell = new HtmlTableCell();
    	cell.InnerText = "col 1";
    	row.Cells.Add(cell);
    
    	cell = new HtmlTableCell();
    	cell.InnerText = "col2";
    	row.Cells.Add(cell);
    
    	baseTable.Rows.Add(row);
    
    	baseTable.Border = 1;
    
        //Create a container cell for inner table
    	HtmlTableRow container = new HtmlTableRow();
    	HtmlTableCell containerCell = new HtmlTableCell();
    	containerCell.Controls.Add(innerTable);
    	containerCell.ColSpan = 2;
    	container.Cells.Add(containerCell);
    	baseTable.Rows.Add(container);
    	if (j < 5)
    	{
    		j++;
    		Addtable(innerTable, j);
    
    	}
    }
