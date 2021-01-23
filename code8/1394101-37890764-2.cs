    private void gridview_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
    {
    	//assume colMaxRate is your Max Rate column name
    	if (e.Column.FieldName == colMaxRate.FieldName) {
    		//do your calculation you need, in this example, find max value of next 4 rows including current row
    		int maxValue = 0;
    		//initialize maxValue to current row's value
    		maxValue = gridview.GetRowCellValue(e.RowHandle, colRate.FieldName);
    		for (rowIndex = 0; rowIndex < 4; rowIndex++) {
    			//TODO: do your own checking to make sure you don't exceed last row count
    			if (maxValue > gridview.GetRowCellValue(e.RowHandle + rowIndex, colRate.FieldName)) {
    				maxValue = gridview.GetRowCellValue(e.RowHandle + rowIndex, colRate.FieldName);
    			}
    		}
    		e.DisplayText = maxValue.ToString();
    		e.Handled = true;
    	}
    }
