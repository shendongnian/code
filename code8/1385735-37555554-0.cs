    // Make a datatable Result
    var dtResult = new DataTable();
    dtResult.Columns.Add("Assigned_Indivual");
    dtResult.Columns.Add("Resolved");
    dtResult.Columns.Add("SLA Alert");
    dtResult.Columns.Add("SLA Missed");
    
    // Get All assigneds
    var assigneds = dTable.AsEnumerable().Select(a => a.Field<string>("Assigned_Individual")).Distinct();
    
    foreach(var assigned in assigneds)
    {
    	// Get All results os assigned indexed
    	var resultOfAssigned = dTable.AsEnumerable().Where(a => a.Field<string>("Assigned_Individual") == assigned).ToList();
    	
    	// Count of results
    	var resultResolved = resultOfAssigned.Where(a => a.Field<string>("Status") == "Closed").Count();
    	var resultAlert = resultOfAssigned.Where(a => a.Field<string>("Alert_Status") == "SLA Alert" && a.Field<string>("Status") == "Resolved" && a.Field<string>("Status") == "Closed").Count();
    	var resultMissed = resultOfAssigned.Where(a => a.Field<string>("Alert_Status") == "SLA Missed" && a.Field<string>("Data_Output_Type") == "Active Tickets").Count();
    
    	// Define a data row
    	var dRow = dtResult.NewRow();
    	dRow[0] = assigned;
    	dRow[1] = resultResolved;
    	dRow[2] = resultAlert;
    	dRow[3] = resultMissed;
    
    	// Insert datarow in Datatable result
    	dtResult.Rows.Add(dRow);
    }
;)
