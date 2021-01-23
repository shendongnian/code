    using (var con = ConnectionFactory.CreateConnection(_connectionString))
	{
        List<ErrorReport> reports = 
		    con.Query<dynamic>("Select * from ErrorReports").AsEnumerable()
                .Select(x => new ErrorReport 
    			{ 
    				Id = x.Id, 
    				Exception = new ExceptionReport
    				{
    					Type = x.ExceptionType,
    					Messsage = x.ExceptionMessage
    				},
    				InnerException = new ExceptionReport
    				{
    					Type = x.InnerExceptionType,
    					Messsage = x.InnerExceptionMessage
    				}
    			}).ToList();
	}
