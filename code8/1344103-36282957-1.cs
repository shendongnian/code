    // Reading xls-file data with CSharpJExcel
    
    var cellsData = new List<List<string>>();
    
    var book = Workbook.getWorkbook(new FileInfo(fileName));
    var dataSheet = book.getSheet(0);
    
    // Loop over rows and fill collection with data
    for (int r = 0; r < dataSheet.getRows(); r++)
    {
    	var dataRow = new List<string>();
    
    	// Loop over columns  
    	for (int c = 0; c < dataSheet.getColumns(); c++)
    	{
    		var cellValue = dataSheet.getCell(c, r).getContents();
    		dataRow.Add(cellValue);
    	}
    
    	cellsData.Add(dataRow);
    }
    
    
    // Saving data to xlsx file with EPPlus
    using (var xls = new ExcelPackage(new FileInfo(path + ".xlsx")))
    {
    	var sheet = xls.Workbook.Worksheets.Add("test");
    	
    	int row = 1;
    	foreach (var cellsRow in cellsData)
    	{
    		int col = 1;
    		
    		// Some data processing logic...
    		
    		foreach (var cellData in cellsRow)
    		{
    			sheet.Cells[row, col].Value = cellData;
    
    			++col;
    		}
    		++row;
    	}
    
    	xls.Save();
    }
