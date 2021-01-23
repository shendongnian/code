    static void Main(string[] args)
    {
    try
    {
        ReadInData readInData = new ReadInData(@"C:\SC.xlsx", "sc_2014");
        IEnumerable<Recipient> recipients = readInData.GetData();
    }
    catch (Exception ex)
    {
        if(!(ex is FileNotFoundException || ex is ArgumentException || ex is FileToBeProcessedIsNotInTheCorrectFormatException))
            throw;
        Console.WriteLine(ex.Message);
    }
    Console.Write(Press any key to continue...);
    Console.ReadKey(true);
    }
    public static class ReadInData
    {
    public static IEnumerable<Recipient> GetData(string path, string worksheetName, bool isFirstRowAsColumnNames = true)
    {
        return new ExcelData(path).GetData(worksheetName, isFirstRowAsColumnNames)
            .Select(dataRow => new Recipient()
            {
                Municipality = dataRow["Municipality"].ToString(),
                Sexe = dataRow["Sexe"].ToString(),
                LivingArea = dataRow["LivingArea"].ToString()
            });
    }
    }
    private static IExcelDataReader GetExcelDataReader(string path, bool isFirstRowAsColumnNames)
    {
    using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
    {
        IExcelDataReader dataReader;
        if (path.EndsWith(".xls"))
            dataReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
        else if (path.EndsWith(".xlsx"))
            dataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
        else
            throw new FileToBeProcessedIsNotInTheCorrectFormatException("The file to be processed is not an Excel file");
        dataReader.IsFirstRowAsColumnNames = isFirstRowAsColumnNames;
        return dataReader;
    }
    }
    private static DataSet GetExcelDataAsDataSet(string path, bool isFirstRowAsColumnNames)
    {
    return GetExcelDataReader(path, isFirstRowAsColumnNames).AsDataSet();
    }
    private static DataTable GetExcelWorkSheet(string path, string workSheetName, bool isFirstRowAsColumnNames)
    {
    DataTable workSheet = GetExcelDataAsDataSet(path, isFirstRowAsColumnNames).Tables[workSheetName];
    if (workSheet == null)
        throw new WorksheetDoesNotExistException(string.Format("The worksheet {0} does not exist, has an incorrect name, or does not have any data in the worksheet", workSheetName));
    return workSheet;
        }
    private static IEnumerable<DataRow> GetData(string path, string workSheetName, bool isFirstRowAsColumnNames = true)
    {
    return from DataRow row in GetExcelWorkSheet(path, workSheetName, isFirstRowAsColumnNames).Rows select row;
    }
