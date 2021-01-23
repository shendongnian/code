    DataTable tableA = ...; // query schema for TableA
    DataTable tableB = ...; // query schmea for TableB
    
    List<String> usernames = select distinct username from TableA;
    Hashtable htUsername = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
    foreach (String username in usernames)
         htUsername[username] = "";
    
    int colUsername = ...;
    foreach (String[] row in CSVFile) {
    	String un = row[colUsername] as String;
    	if (htUsername[un] == null) {
    		// add new row to tableA
    		DataRow row = tableA.NewRow();
    		row["Username"] = un;
    		// etc.
    		tableA.Rows.Add(row);
    		htUsername[un] = "";
    	}
    }
    
    // bulk insert TableA
    
    select userid, username from TableA
    Hashtable htUserId = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
    // htUserId[username] = userid;
    
    int colUserId = ...;
    
    foreach (String[] row in CSVFile) {
    
    	String un = row[colUsername] as String;
    	int userid = (int) htUserId[un];
    	DataRow row = tableB.NewRow();
    	row[colUserId] = userId;
    	// fill in other values
    	tableB.Rows.Add(row);
    	if (table.Rows.Count == 65000) {
    		// bulk insert TableB
    		var t = tableB.Clone();
    		tableB.Dispose();
    		tableB = t;
    	}
    }
    
    if (tableB.Rows.Count > 0)
    	// bulk insert TableB
