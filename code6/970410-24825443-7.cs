    public User GetUserByUserName(string userName)
    {
    	return this.GetFromDictionary<User>(MultiKey.Type.UserName, userName);
    }
    
    public User GetIndividualByEmployeeNumber(string employeeNumber)
    {
    	return this.GetFromDictionary<User>(MultiKey.Type.EmployeeNumber, employeeNumber);
    }
