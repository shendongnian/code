    public class DepartmentEmployeesModel
	{
		public string DepartmentId { get; set; }
		public string Employees { get; set; }
	}
    return Context
             .Employees
             .GroupBy(e => e.DepartmentID)
             .Select(x => new DepartmentEmployeesModel { DepartmentId = x.Key, Employees = x.Count() }).ToList();
