    Excel.PivotTables pivotTables = worksheet.PivotTables(Type.Missing);
    
    foreach (Excel.PivotTable p in pivotTables){
        if(p.ActiveFilters.Count > 1){
             //your code
        }
    }
