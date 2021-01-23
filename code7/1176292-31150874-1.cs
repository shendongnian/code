    using Microsoft.Office.Interop.Excel;
    
    public void SyncData(Worksheet ws, DataTable dt, int startRow){
        //Get the columns and their corresponding indexes in excel
        Dictionary<string, int> columnMap = ExcelColumnResolver(ws, dt, 1);
        
        //The row number in excel youre starting to update from
        int currRow = startRow;
        
        //Iterate through the rows and the columns of each row
        foreach(DataRow row in dt.Rows){
            foreach(DataColumn column in dt.Columns){
                
                //Only update columns we have mapped
                if(columnMap.ContainsKey(column.ColumnName)){
                    ws.Cells[currRow, columnMap[column.ColumnName]] = row[column.ColumnName];
                }
            }
            
            currRow++;
        }
    }
    
    //columnsRow = Row in which the column names are located (non-zero indexed)
    public Dictionary <string, int> ExcelColumnResolver(Worksheet ws, DataTable dt, int columnsRow) {
    	Dictionary<string, int> nameToExcelIdxMap = new Dictionary<string, int>();
    
    	//The row in Excel that your column names are located
    	int maxColumnCount = 10;
    
        //Excel cells start at index 1
    	for (int i = 1; i < maxColumnCount; i++) {
    		string col = ws.Cells[columnsRow, i].ToString();
    		
    		if (dt.Columns.Contains(col)){
    		    nameToExcelIdxMap[col] = i;
    	    }
    	}
    	
    	return nameToExcelIdxMap;
    }
