    public ExcelReader(string connectionString)
    {
        _connectionString = connectionString;
    }
    public DataSet ConvertToDataSet(string workSheetName)
    {
        OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + workSheetName + "$]", ConnectionString);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "Standard");
        return ds;
    }
