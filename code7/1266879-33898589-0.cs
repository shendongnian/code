    //Get file path
    var excelFile = new FileInfo("your-path-here");
    //Open file using epplus
    using(var package = new ExcelPackage(excelFile))
    {
        ExcelWorkbook wkbk = package.Workbook;
        
        //Make sure file is not empty
        if(wkbk != null)
        {
            if(wkbk.Worksheets.Count > 0)
            {
                //Get the first worksheet
                ExcelWorksheet curworksheet = wkbk.Worksheets.First();
                //Get row count
                var row = curworksheet.Dimension.End.Row;
                //Get column count
                var col = curworksheet.Dimension.End.Column;
                
                //Cycle through rows
                foreach(int i = 2; i <= row; i++)
                {
                    //Cycle through columns for current row
                    foreach(int = 1; i <= col; i++)
                    {
                        //for each col do something...
                    }
                }
            }
        }
         
    }
