    public List<Student> GetStudentData()
    {
        List<Student> dataStudent;
        using (IDbConnection connection = RepositoryHelper.OpenConnection())
        {
            dataStudent = connection.Query<Student>(
    			"mystoredprocedure", 
    			commandType: CommandType.StoredProcedure)
    				.GroupBy(x => x.StudentId)
    				.Select(x => new Student 
    					{ 
    						StudentId = x.StudentId, 
    						EmailAddresses = x.Select(ea => new EmailAddress 
                                { 
                                    EmailAddress = ea.EmailAddress 
                                }).ToList()
    					}).ToList();
    
        	return dataStudent;
    	}
    }
