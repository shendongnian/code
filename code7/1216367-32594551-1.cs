    // Set the Access Token.
    Token token = new Token();
    token.AccessToken = YOUR_ACCESS_TOKEN;
    
    // Use the Smartsheet Builder to create a Smartsheet.
    SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(token.AccessToken).Build();
    
    // Get Sheet.
    long sheetId = YOUR_SHEET_ID;
    Sheet sheet = smartsheet.SheetResources.GetSheet(sheetId, null, null, null, null, null, null, null);
    
    // Identify Row hierarchy by examining the ParentId property of each row.
    foreach (Row row in sheet.Rows)
    {
    	if (row.ParentId != null)
    	{
    		Response.Write("Row #" + row.RowNumber.ToString() + " (Id=" + row.Id.ToString() + ") is a child of Row Id " + row.ParentId.ToString() + "<br/><br/>");
    	}
    	else
    	{
    		Response.Write("Row #" + row.RowNumber.ToString() + " (Id=" + row.Id.ToString() + ") is a top-level row.<br/><br/>");
    	}
    }
    
    /************************************************
     * Add new row.
    /************************************************/
    
    // Specify cell values for the row.
    Cell[] cells = new Cell[] { new Cell.AddCellBuilder(2069395137685380, "New Task").Build(), new Cell.AddCellBuilder(4743407416436612, "Added via API").SetStrict(false).Build() };
    
    // Specify the Id of the parent row.
    long parentId = 1085142354683780;
    
    // Specify contents and placement of new row.
    // Use the 5 parameters of the "AddRowBuilder" function to specify row's placement: toTop, toBottom, parentId, siblingId, above
    // Specifying parentId only will add the new row as the first child row under the specified parent row.
    Row newRow = new Row.AddRowBuilder(null, null, parentId, null, null).SetCells(cells).Build();
    
    // Add row to sheet.
    smartsheet.SheetResources.RowResources.AddRows(sheetId, new Row[] { newRow });
