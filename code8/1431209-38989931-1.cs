    public CommandResult<int> ReadYearAndMonth()
    {
    	CommandResult<int> result = null;
    	try
    	{
    		var collection = this.GetCollection<Holiday>();
    
    		List<Holiday> holidays = collection.Find(filter).ToListAsync().GetAwaiter().GetResult();
    
    		List<int> UniqueYears = holidays.Select(t => t.HolidayDateTime.Year)
    		            .Distinct()
    		            .ToList();
    
    		result = new CommandResult<int>(uniqueYears, "Years found", CommandStatus.Success);
    	}
    	catch (Exception ex)
    	{
    		result = new CommandResult<int>(ex, "Error reading Years");
    	}
    	return result;
    }
