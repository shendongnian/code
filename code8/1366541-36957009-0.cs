    // Open the workbook
    using (var package = new ExcelPackage(new FileInfo("PriceQuoteTemplate.xlsx")))
    {
        // Get the worksheet I'm looking for
        var quoteSheet = package.Workbook.Worksheets["Quote"];
 
        //If I wanted to get the text from one named range
        var cellText = quoteSheet.Workbook.Names["myNamedRange"].Text
        //If I wanted to get the cell's value as some other type
        var cellValue = quoteSheet.Workbook.Names["myNamedRange"].GetValue<int>();
        //If I had a named range and I wanted to loop through the rows and get 
        //values from certain columns
        var myRange = quoteSheet.Workbook.Names["rangeContainingRows"];
        
        //This is a named range used to mark a column. So instead of using a
        //magic number, I'll read from whatever column has this named range.
        var someColumn = quoteSheet.Workbook.Names["columnLabel"].Start.Column;
        
        for(var rowNumber = myRange.Start.Row; rowNumber < myRange.Start.Row + myRange.Rows; rowNumber++)
        {  
            var getTheTextForTheRowAndColumn = quoteSheet.Cells(rowNumber, someColumn).Text
        }
