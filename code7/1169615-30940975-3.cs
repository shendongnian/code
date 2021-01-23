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
    						StudentId = x.First().StudentId, 
                            Gender = x.First().Gender,
    						EmailAddresses = x.Select(ea => new EmailAddresses 
                                { 
                                    EmailAddress = ea.EmailAddresses 
                                }).ToList()
    					}).ToList();
    
        	return dataStudent;
    	}
    }
