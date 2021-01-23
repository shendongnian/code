    public class Company
    {
    	public Company()
    	{
    		this.Employees = new List<Employee>();
    	}
    	
    	[JsonConverter(typeof(EmployeeConverter))]
    	public List<Employee> Employees { get; set; }
    }
