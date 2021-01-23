    Dictionary<int, List<string>> dbDict = new Dictionary<int, List<string>>();
    
    do
    {
    	List<string> dbList = new List<string>();
    	dbList.Add("Field1 : " (String)rs.Fields["Field1"].Value);
    	dbList.Add("Field2 : " rs.Fields["Field 2"].Value);
    	dbList.Add("Field3 : " (String)rs.Fields["Field3"].Value);
    	dbDict.add(i,dbList);
    	i+=1;
    	rs.MoveNext();
    }
    while (rs.EOF == false);
