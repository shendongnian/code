    public CommandResult<int> ReadYearAndMonth()
    {
    	CommandResult<int> result = null;
    	try
    	{
    		var collection = this.GetCollection<Holiday>();
    		var group = new BsonDocument
    		{
    			{ "_id", new BsonDocument
    				{
    					{ "year", new BsonDocument("$year", "$HolidayDateTime") }
    				}
    			}
    		};
    
    		var project = new BsonDocument
    		{
    			{"_id", 0},
    			{"HolidayDateTime", "$_id.year"}
    		};
    
    		var years = collection.Aggregate().Group(group).Project(project).ToListAsync().Result;
    
    		List<int> uniqueMonthYears = years.Select(x => x["HolidayDateTime"].AsInt32).ToList();
    
    		result = new CommandResult<int>(uniqueMonthYears, "Years found", CommandStatus.Success);
    	}
    	catch (Exception ex)
    	{
    		result = new CommandResult<int>(ex, "Error reading Years");
    	}
    	return result;
    }
