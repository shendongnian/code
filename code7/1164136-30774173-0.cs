    void Main()
    {
    	// Create a new DataTable
    	DataTable tbl = GetData();
    	// Add Position column and initialize it
    	tbl.Columns.Add("Position", typeof(int));
    	for(int i = 0; i < tbl.Rows.Count; i++) 
    		tbl.Rows[i]["Position"] = i;
    	PrintView("Original", tbl.DefaultView);
    	
    	// Create a view that is sorted by the Position column
    	var view = new DataView(tbl);
    	view.Sort = "Position";
    	PrintView("Sorted", view); // No change as the rows are in original order anyway
    	
    	// Move a row
    	SwapPositions(view, 0, 1); // Move first row down
    	PrintView("Swapped", view);
    }
    
    private DataTable GetData()
    {
    	DataTable tbl = new DataTable();
    	tbl.Columns.Add("Value", typeof(string));
    	for(int i = 0; i < 3; i++)
    		tbl.Rows.Add("Text " + i.ToString());
    	return tbl;
    }
    
    private void PrintView(string header, DataView view)
    {
    	Console.WriteLine(header);
    	foreach(DataRowView row in view)
    		Console.WriteLine("{0}\t{1}", row["Position"], row["Value"]);
    }
    
    private void SwapPositions(DataView view, int rowIndex1, int rowIndex2)
    {
    	// Save rows as the change in the Position column is reflected immediately
    	DataRowView row1 = view[rowIndex1];
    	DataRowView row2 = view[rowIndex2];
        // Now swap positions
    	var saveValue = row1["Position"];
    	row1["Position"] = row2["Position"];
    	row2["Position"] = saveValue;
    	view.Table.AcceptChanges();
    }
