    public async Task<List<Company>> SearchByName(string searchText)
    {
    	var results = new List<Company>();
    
    	if (string.IsNullOrWhiteSpace(searchText))
    		return results;
    
    	if (searchText.IndexOf("&") >= 0)
    	{
    		var likeQuery = string.Format("%{0}%", searchText);
    
    		results = await DataContext.Company.SqlQuery("SELECT CompanyId AS Id, IsEligible AS IsReadOnly, *" +
    								"  FROM Company.Company AS con" +
    								"  WHERE con.Name LIKE @SearchText",
    			new SqlParameter("@SearchText", likeQuery))
    			.ToListAsync();
    	}
    	else
    	{
    		var terms = ParseSearchTextForMultiwordSearch(searchText);
    
    		if (string.IsNullOrWhiteSpace(terms))
    			return results;
    
    		// SqlQuery does not take any column mappings into account (https://entityframework.codeplex.com/workitem/233)
    		// So we have to manually map the columns in the select statement
    		var sqlQueryFormat = "SELECT CompanyId AS Id, IsEligible AS IsReadOnly, *" +
    								"  FROM Company.Company AS con" +
    								"  WHERE {0}(con.Name, @SearchText)";
    
    		var sqlQuery = string.Format(sqlQueryFormat, "CONTAINS");
    		var errored = false;
    
    		try
    		{
    			results = await DataContext.Company.SqlQuery(sqlQuery,
    			new SqlParameter("@SearchText", terms))
    			.ToListAsync();
    		}
    		catch
    		{
    			//catch the error but do nothing with it
    			errored = true;
    		}
    
    		//when the contains search fails due to some unknown error, use Freetext as a backup
    		if (errored)
    		{
    			sqlQuery = string.Format(sqlQueryFormat, "FREETEXT");
    
    			results = await DataContext.Company.SqlQuery(sqlQuery,
    			new SqlParameter("@SearchText", terms))
    			.ToListAsync();
    		}
    	}
    
    	return results;
    }
