    // Thanks to the generics power, each builder derived class
    // will must provide the employee type to build, and it must be
    // Employee or a derived of Employee class.
    public class EmployeeBuilder<TEmployee>
    	where TEmployee : Employee, new ()
    {
    	public virtual void BuildObject(TEmployee employee = null)
    	{
            // If an instance is given as argument ok, if not 
            // one is created from scratch!
    		TEmployee emp = employee ?? new TEmployee();
    		emp.DailyWorkHours = "8hours";
    		emp.WeeklyHolidays = "saturday and Sunday";
    	}
    }
    
    public class ContractEmployeeBuilder<TEmployee> : EmployeeBuilder<TEmployee> where TEmployee : ContractEmployee, new ()
    {
    	public override void BuildObject(TEmployee employee = null)
    	{
            // If an instance is given as argument ok, if not 
            // one is created from scratch!
    		TEmployee emp = employee ?? new TEmployee();
    		emp.ContractDuration = "1 month";
    		base.BuildObject(emp);
    	}
    }
    
    public class FullTimeEmployeeBuilder<TEmployee> : EmployeeBuilder<TEmployee> where TEmployee : FullTimeEmployee, new ()
    {
    	public override void BuildObject(TEmployee employee = null)
    	{
            // If an instance is given as argument ok, if not 
            // one is created from scratch!
    		TEmployee emp = employee ?? new TEmployee();
    		emp.MonthlySalary = "£2500";
    		base.BuildObject(emp);
    	}
    }
