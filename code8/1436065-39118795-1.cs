    using System;
	using System.Security.Permissions;
	[PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
	public class EmployeeManager
	{
	    [PrincipalPermission(SecurityAction.Demand, Role = "Manager")]
	    public Employee LookupEmployee(int employeeID)
	    {
	       // todo
	    }
	    [PrincipalPermission(SecurityAction.Demand, Role = "HR")]
	    public void AddEmployee(Employee e)
	    {
	       // todo
	    }
	}
