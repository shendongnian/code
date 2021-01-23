    public class DepartmentEmployeesModel
	{
		public string DepartmentName { get; set; }
		public string Employees { get; set; }
	}
    return Context
             .Employees
             .GroupBy(e => e.DepartmentID)
             .Select(x => new DepartmentEmployeesModel { DepartmentName = x.Key, Employees = x.Count() }).ToList();
