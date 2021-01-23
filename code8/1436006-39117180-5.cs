	public class EmployeeDetailsController : Controller
	{
		public IEnumerable<Employee> GetEmployees()
		{
			// Get your list of employees here
			return ...;
		}
		public IEnumerable<Detail> GetDetails(int employeeId = 0)
		{
			// Get your list of details here
			return ...;
		}
		public IEnumerable<Team> GetTeams(int employeeId = 0)
		{
			// Get your list of teams here
			return ...;
		}
		public IEnumerable<Detail> GetDetailsForTeam(int employeeId = 0, int teamId = 0)
		{
			// Get your list of details here
			return ...;
		}
	}
