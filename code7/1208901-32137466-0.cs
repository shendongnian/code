    public DataSet getData(string path)
    {
        FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        DataSet result = excelReader.AsDataSet();
        return result;
    } 
