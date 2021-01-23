    public IEnumerable<DataRow> GetFirstSheetData(bool firstRowIsColumnNames = false)
    {
        var reader = this.getExcelReader();
        reader.IsFirstRowAsColumnNames = firstRowIsColumnNames;
        return reader.AsDataSet().Tables[0].AsEnumerable();
    }
