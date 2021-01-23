    using (eds ctx = new eds())
    {
    	string targetText = "This is a sample string with words that will get replaced based on data pulled from the database";
    
    	var builder = new StringBuilder(targetText);
    
    	List<parameter> lstParameters = ctx.ciParameters.ToList();
    	foreach (parameter in lstParameters)
    	{
    		string searchKey = parameter.searchKey;
    		string newValue = parameter.value;
    		targetText = builder.Replace(searchKey, newValue);
    	}
    }
