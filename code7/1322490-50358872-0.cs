    #region PivotTables
    public static List<DataTable> PivotCollection(string filePath)
    {
        List<DataTable> pivotCollection = new List<DataTable>();
        //Get Workbook
        xl.Application app = new xl.Application();
        xl.Workbook wb = null;
        wb = app.Workbooks.Open(filePath);
        
        //Loop through each worksheet and find pivot tables to add to collection
        foreach (xl.Worksheet ws in wb.Worksheets)
        {
            //Get range of pivot table
            string wsName = ws.Name.ToString();
            xl.Range pivotRange = GetPivotRange(ws);
            //Check if there is any table to add
            if (pivotRange == null) continue;
            DataTable pivotTable = DataTables.FromRange(pivotRange);
            //Get info from range and add to pivot
            pivotCollection.Add(pivotTable);
        }
        return pivotCollection;
    }
    //Find Pivot table in worksheet
    //CS's Code with slight modification, use worksheet instead of range
    public static xl.Range GetPivotRange(xl.Worksheet xlworkSheet)
    {
        xl.Range pivotRanges = null;
        xl.PivotTables pivotTables = xlworkSheet.PivotTables();
        int pivotCount = pivotTables.Count;
        for (int i = 1; i <= pivotCount; i++)
        {
            xl.Range tmpRange = xlworkSheet.PivotTables(i).TableRange2;
            if (pivotRanges == null) pivotRanges = tmpRange;
            pivotRanges = tmpRange;
        }
        return pivotRanges;
    }
    #endregion
    
