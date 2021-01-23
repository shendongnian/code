    public ExcelReader(filePath)
    {
        var isXls = Path.GetExtension(_filePath) == ".xls";
        var workBook = GetWorkBook(); //then cast or return object directly
        //Other init...
    }
    public object GetWorkBook()
    {        
        return Workbook.GetSheetAt();
    }
