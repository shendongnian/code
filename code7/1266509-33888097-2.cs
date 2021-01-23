    public class EmployeeViewModel
    {
    	public IEnumerable<Employee> Employees { get; set; }
    	public int TotalAvailable { get { return Employees.Count(emp => emp.Available); } }
    	public int TotalUnavailable { get { return Employees.Count(emp => emp.Unavilable); } }
    	public int TotalAway { get { return Employees.Count(emp => emp.Away); } }
    	public int TotalOnLeave { get { return Employees.Count(emp => emp.OnLeave); } }
    
    }
    
    public class Employee
    {
    	public bool Available { get; set; }
    	public bool Unavilable { get; set; }
    	public bool Away { get; set; }
    	public bool OnLeave { get; set; }
    }
    //In the controller do this.
    public ActionResult Index() //use your controller Action Name here
    {
    	var employeeViewModel = new EmployeeViewModel { Employees = /*Your list of empoyees you had as a Model before here*/}
        return View(employeeViewModel)
    }
