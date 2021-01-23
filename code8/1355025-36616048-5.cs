    try
    {
        using(System.IO.FileStream fs = new System.IO.FileStream(FullfilePath, System.IO.FileMode.Open, FileAccess.ReadWrite))
        {
            startTime = DateTime.Now;
            IExcelDataReader excelReader2007 = ExcelReaderFactory.CreateOpenXmlReader(fs);
            excelReader2007.IsFirstRowAsColumnNames = false;
            DataSet result = excelReader2007.AsDataSet();
            if (result.Tables.Count > 0)
            {
                ds = result;
            }
        
            InsertExecLogDetails(startTime, DateTime.Now, Convert.ToString(Common.EventNames.GenerateDataTableFromExcel), Convert.ToString(Common.StatusEnum.Success), "Table generated from excel");
        }
    }
    catch (Exception ex)
    {
        InsertExecLogDetails(startTime, DateTime.Now, Convert.ToString(Common.EventNames.GenerateDataTableFromExcel), Convert.ToString(Common.StatusEnum.Failure), Convert.ToString(ex.Message));
    }
