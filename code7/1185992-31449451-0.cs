    public ActionResult Index() 
    {
    	var viewModel = new ViewModel()
    	{
    		Employees = BuildListOfEmployees() // Method that gets/builds a list of employees, expected return type List<Employee>
    	};
    
    	return View(viewModel);
    }
    
    class ViewModel
    {
    	public List<Employee> Employees { get; set; }
    }
