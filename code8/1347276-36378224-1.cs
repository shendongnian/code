    void Main()
    {  	
    	List<DisplayColumn> dataList = new List<DisplayColumn>();
    	dataList.Add(new DisplayColumn("Firstname", "Sasi"));
    	dataList.Add(new DisplayColumn("Lastname", "verpal"));
    	dataList.Add(new DisplayColumn("Age", "30"));
    	dataList.Add(new DisplayColumn("Location", "Veega"));
    
    	// However, in your case you can add the values using
    	foreach (var column in myTable.Rows[0].Columns)
    	{
    		dataList.Add(new Tuple<string, string>(column.Name, column.Value.ToString()));
    	}
        // Now bind the dataList to your grid
    }
    
    public class DisplayColumn
    {
    	public string ColumnName { get; set; }
    	public string ColumnValue { get; set; }
    	
    	public DisplayColumn(string columnName, string columnValue)
    	{
    		ColumnName = columnName;
    		ColumnValue = columnName;
    	}
    }
