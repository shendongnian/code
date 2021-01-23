    public ExcelReader(filePath)
    {
        var isXls = Path.GetExtension(_filePath) == ".xls";
        var type = isXls ? typeof(HSSFWorkbook) : typeof(XSSFWorkbook); //get the type for the method
        var getWorkBook = this.GetType().GetMethod("GetWorkBook"); //get the generic method dynamically
        var genericGetWorkBook = getWorkBook.MakeGenericMethod(type); //use the type
        var workBook = genericGetWorkBook.Invoke(this, null); //call the method
        //Other init...
    }
