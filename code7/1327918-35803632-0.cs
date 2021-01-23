    public void printToExcel(string vOutputPath)
    {
    	string sExcelPath = @"C:\Users\jhochbau\Desktop\Test.xlsx";
    	ExcelHelper excel = new ExcelHelper(sExcelPath);
    	excel.OpenWorkbook();
    	int curRow = 1; //initialize to your starting row for data printing
    	foreach (KeyValuePair<string, List<DataRecord>> kvp in vSummaryResults)
    	{
    		string key = kvp.Key; //assigns key
    
    		List<DataRecord> list = kvp.Value;  //assigns value
    
    		int iSumOpen = 0;
    		int iSumBuy = 0;
    		int iSumSell = 0;
    		double iSumSettleMM = 0;
    
    		foreach (DataRecord rec in list)
    		{
    			//No need to check vSummaryResults.ContainsKey(key) here, because you already took the key from the dictionary 
    			//in 'string key = kvp.Key;' so you know it exists unless you've removed it
    			iSumOpen += rec.open;
    			iSumBuy += rec.buy;
    			iSumSell += rec.sell;
    			iSumSettleMM += rec.settleMM;
    		}
    		//WriteToSheet params: int row, int column, and value injected
    		//need to create some counters here to move the rows and columns?
    		int iColumn = 1;
    		excel.WriteToSheet(curRow, iColumn, key);
    		excel.WriteToSheet(curRow, iColumn + 1, iSumOpen);
    		excel.WriteToSheet(curRow, iColumn + 2, iSumBuy);
    		excel.WriteToSheet(curRow, iColumn + 3, iSumSell);
    		excel.WriteToSheet(curRow, iColumn + 4, iSumSettleMM);
    		curRow += 1; //increment to the next data row in the sheet
    	}
    }
