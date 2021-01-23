    private void mergeduplicate(DataSet importedData)
    {
    	Dictionary<String, List<DataRow>> systems = new Dictionary<String, DataRow>();
    	foreach (DataRow dr in importedDataCopy.Tables[0].Rows)
    	{
    		String systemName = dr["Computer Name"].ToString();
    		if (!systems.ContainsKey(systemName)) 
    		{
    			systems.Add(systemName, dr);
    		}
    		else
    		{
    			// Existing date is the date in the dictionary.
    			DateTime existing = Validation.ConvertStringIntoDateTime(systems[systemName]["date"].ToString());
    			
    			// Candidate date is the date of the current DataRow.
    			DateTime candidate = Validation.ConvertStringIntoDateTime(dr["date"].ToString());
    			
    			// If the candidate date is greater than the existing date then replace the existing DataRow
    			// with the candidate DataRow.
    			if (DateTime.Compare(existing, candidate) < 0) 
    			{
    				systems[systemName] = dr;
    			}
    		}
    	}
    }
