    string[] srr = new string[]{"Col2","Col1","Col3","Test","Test1","Col6","Col4","Some col name","Col5"};
    		
    DataTable MyDataTable = new DataTable();
    
    foreach(string col in srr)
    {
    	MyDataTable.Columns.Add(col);				
    }
    
    List<string> arrayNames = (from DataColumn x in MyDataTable.Columns
    					  select x.ColumnName).ToList();
    
    foreach(var col in arrayNames)
    {
    	if(!col.Contains("Col"))
    	{
    		MyDataTable.Columns.Remove(col);			
    	}
    	else
    	{
    		int result = Convert.ToInt32(Regex.Match(col.ToString(), @"\d+$").Value);
    		MyDataTable.Columns[col].SetOrdinal(result-1);			
    	}
    }
    		
