     public void AddNewEmployee(Employee employee){
        this.Employees.Add(employee);			
        bool all = true;
			
        foreach(Employee emp in this.Employees){
			if (!emp.IsEngagedwithWork){
                all = false;
                break;
            }
		}
		
		this.IsAllEmpEngaged = all;          
	}
	
