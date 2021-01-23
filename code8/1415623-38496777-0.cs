    public bool IsAllEmpEngaged()
    {
    	if (Employees == null)
        {
            // throw error
        }
    
    	return Employees.All(e => e.IsEngagedwithWork);
    }
