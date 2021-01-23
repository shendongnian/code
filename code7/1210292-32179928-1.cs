    var rowCounter = 0;
    var cellCounter = 0;
    foreach (GridViewRow row in grdHorizontalSeatDashboard.Rows)
    {
        foreach (TableCell cell in row.Cells)
        {
        	if (rowCounter == 0 && cellCounter == 0) 
        	{
        		cell.Text = "";
        	}
    
            cell.BackColor = row.BackColor;
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.CssClass = "textmode";
        }
        cellCounter = 0;
        rowCounter++;
    }
