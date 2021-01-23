    private void mergeduplicate(DataSet importedData)
    {
        Dictionary<String, DataRow> systems = new Dictionary<String, DataRow>();
    	int i = 0;
    
    	while (i < importedData.Tables[0].Rows.Count)
        {
    		DataRow dr = importedData.Tables[0].Rows[i];
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
                // with the candidate DataRow and delete the existing DataRow from the table.
                if (DateTime.Compare(existing, candidate) < 0) 
                {
    				importedData.Tables[0].Rows.Remove(systems[systemName]);
                    systems[systemName] = dr;
                }
            }
    		i++;
        }
    }
