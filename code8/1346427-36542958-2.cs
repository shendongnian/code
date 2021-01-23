    List<dynamic> allRecords = new List<dynamic>();  //A list of all my records
    List<dynamic> singleRecord = null;  //A list representing just a single record
    
    bool first = true;   //Needed for execution of the first iteration only
    int lastId = 0;      //id of the last unique record
    
    foreach (DataRow row in args.GetDataSet.Tables[0].Rows)
    {
    	int newID = Convert.ToInt32(row["UniqueID"]);  //get the current record unique id   
                        
    	if (newID != lastId)  //If new record then get header/parent information
        {
    		if (!first)
    			allRecords.Add(singleRecord);   //store the last record
            else
    			first = false;
    
    		//new object
    		singleRecord = new List<dynamic>();
    
    		//get parent information and store it
            dynamic head = new ExpandoObject();
            head.Column_name = "UniqueID";
            head.UDS_Data = row["UniqueID"].ToString();
            singleRecord.Add(head);
    
            head = new ExpandoObject();
            head.Column_name = "LoadTime";
            head.UDS_Data = row["LoadTime"].ToString();
            singleRecord.Add(head);
    
            head = new ExpandoObject();
            head.Column_name = "reference";
            head.UDS_Data = row["reference"].ToString();
            singleRecord.Add(head);                    
        }
    	
    	//get child information and store it.  One row at a time
        dynamic record = new ExpandoObject();
                    
        record.Column_name = row["column_name"].ToString();
        record.UDS_Data = row["data"].ToString();
        singleRecord.Add(record);
    
        lastId = newID;   //store the last id
    }
    allRecords.Add(singleRecord);  //stores the last complete record
