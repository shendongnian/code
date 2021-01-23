    public class EmployeeRepository {
    	private readonly MyContext _context = new MyContext(); // Or whatever...
    
    	public IList<Employee> GetCoworkers(int userId) {
    		var currentEmployee = _context.Employees
    			.Where(e => e.UserId == userId)
    			.Include(e => e.Job.Department)		// Use eager loading; this will fetch Job and Department rows for this user
    			.FirstOrDefault();
    
    		var department = currentEmployee.Job.Department;
    		var coworkers = department.Jobs.SelectMany(j => j.Employees);
    		return coworkers;
    	}
    }
    
