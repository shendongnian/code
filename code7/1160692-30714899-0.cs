    var dt = new System.Data.DataTable();
    dt.Columns.Add("Series", typeof(string));
    dt.Columns.Add("Date", typeof(DateTime));
    dt.Columns.Add("Value", typeof(string));
        
    //looping through SQL datasource for first series
        while(){
        	dt.Rows.Add("Today", date, value);
        }
    //looping through SQL datasource for second series
    while(){
    	dt.Rows.Add("Yesterday", date, value);
    }
    
    Chart1.Series.Clear();
    Chart1.DataBindCrossTable(dt.Rows, "Series", "Date", "Value", "");
