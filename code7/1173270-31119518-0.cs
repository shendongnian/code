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
    
            dataStudent.ForEach(x => x.emailAddresses = x.emailAddresses
                .Distinct(new StudentEmailEqualityComparer()).ToList());
    
            return dataStudent;
        }
    }
    public class StudentEmailEqualityComparer : IEqualityComparer<EmailAddresses>
	{
	
		public bool Equals(EmailAddresses x, EmailAddresses y)
		{
			return x.EmailAddress.Equals(y.EmailAddress);
		}
	
		public int GetHashCode(EmailAddresses obj)
		{
			return obj.EmailAddress.GetHashCode();
		}
	}
