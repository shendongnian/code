    public void MakeCellVisible(int columnIndex, int rowIndex)
    {
    	var visibleRange = Application.ActiveWindow.VisibleRange;
    	var lastColumn = visibleRange.Column + visibleRange.Columns.Count - 1;
    	var lastRow = visibleRange.Row + visibleRange.Rows.Count - 1;
        int down, toRight;
    	if (rowIndex == lastRow)
    	{
    		down = 1;
    	}
    
    	if (columnIndex == lastColumn)
    	{
    		toRight = 1;
    	}
    	if (0 != down || 0 != toRight)
    	{
    		Application.ActiveWindow.SmallScroll(Down: down, ToRight: toRight);
    	}
    }
 
