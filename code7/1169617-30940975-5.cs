    public List<Student> GetStudentData()
    {
        List<Student> dataStudent;
        using (IDbConnection connection = RepositoryHelper.OpenConnection())
        {
            dataStudent = connection.Query<dynamic>(
    			"mystoredprocedure", 
    			commandType: CommandType.StoredProcedure)
    				.GroupBy(x => x.StudentId)
    				.Select(x => new Student 
    					{ 
    						StudentId = x.First().StudentId, 
                            Gender = x.First().Gender,
    						emailAddresses = x.Select(ea => new EmailAddresses 
                                { 
                                    EmailAddress = ea.emailAddresses 
                                }).ToList()
    					}).ToList();
    
        	return dataStudent;
    	}
    }
