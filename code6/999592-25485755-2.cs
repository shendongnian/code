    public void Addtable(HtmlTable baseTable, int j)
    {
    	HtmlTable innerTable = new HtmlTable();
        // change to stylesheet instead. Just added as an example to get the output
    	baseTable.Style.Add("margin-left", "25px");
    	baseTable.Style.Add("margin-right", "25px");
    	baseTable.Style.Add("margin-bottom", "25px");
    	baseTable.Style.Add("text-align", "center");
    	baseTable.Border = 1;
    
    	//Create a container cell for inner table
    	HtmlTableRow container = new HtmlTableRow();
    	HtmlTableCell containerCell = new HtmlTableCell();
    	Literal l = new Literal();
    	l.Text = "Table " + j;
    	containerCell.Controls.Add(l);
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
