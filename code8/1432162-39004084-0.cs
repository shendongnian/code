    if (e.Row.RowType == DataControlRowType.DataRow && ((e.Row.RowState & DataControlRowState.Edit) == 0))
    {
    	var valueFetched = ((Label)(e.Row.Cells[1].FindControl("yourControlId"))).Text;
    	if (valueFetched == "1")
    	{
    		foreach (var cell in e.Row.Cells)
    			((TableCell)cell).BackColor = System.Drawing.Color.LightBlue;
    	}
    }
