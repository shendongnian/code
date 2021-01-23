    public ExcelReader(filePath)
    {
        var isXls = Path.GetExtension(_filePath) == ".xls";
        
        //Other init...
    }
    public object GetWorkBook()
    {        
        return Workbook.GetSheetAt();
    }
