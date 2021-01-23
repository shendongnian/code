    public Excel.ListObject WriteToExcelTable(Excel.Worksheet WSheet, string TableName, string CellStr = "A1", bool ClearSheetContent = false)
    {
    	Excel.Range range;
    
    	if (ClearSheetContent)
    		WSheet.Cells.ClearContents();  // clear sheet content
    
    	// get upper left corner of range defined by CellStr
    	range = (Excel.Range)WSheet.get_Range(CellStr).Cells[1, 1];   //
    
    	// Write table to range
    	HelperFunc.WriteTableToExcelSheet(WSheet, this._tbl, range.Address);
    
    	// derive range for table, +1 row for table header
    	range = range.get_Resize(this.RowCount + 1, this.ColumnCount);
    
    	// add ListObject to sheet
    
    	// ListObjects.AddEx Method 
    	// http://msdn.microsoft.com/en-us/library/microsoft.office.interop.excel.listobjects.addex%28v=office.14%29.aspx
    
    	Excel.ListObject tbl = (Excel.ListObject)WSheet.ListObjects.AddEx(
    		SourceType: Excel.XlListObjectSourceType.xlSrcRange,
    		Source: range,
    		XlListObjectHasHeaders: Excel.XlYesNoGuess.xlYes);
    
    	// set name of excel table
    	tbl.Name = TableName;
    
    	// return excel table (ListObject)
    	return (Excel.ListObject)tbl;
    }
