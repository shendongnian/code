    // Set the Access Token
    Token token = new Token();
    token.AccessToken = YOUR_ACCESS_TOKEN;
    
    // Use the Smartsheet Builder to create a Smartsheet
    SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(token.AccessToken).Build();
    
    // Get Sheet
    long sheetId = YOUR_SHEET_ID;
    Sheet sheet = smartsheet.SheetResources.GetSheet(sheetId, null, null, null, null, null, null, null);
    
    // Examine columns and write Title and Type for each column.
    foreach (Column column in sheet.Columns)
    {
    	Response.Write(column.Title + ": " + column.Type.ToString() + "<br/><br/>");
    }
