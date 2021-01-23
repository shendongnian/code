    public ExcelReader(filePath)
    {
        var isXls = Path.GetExtension(_filePath) == ".xls";
        var workBook = isXls ? (HSSFWorkbook)GetWorkBook() : (XSSFWorkbook)GetWorkBook();
        //Other init...
    }
    public object GetWorkBook()
    {        
        return Workbook.GetSheetAt();
    }
