    void Main()
    {
    	var employees = new List<Employee>()
    	{
    		new Employee{
    			Name = "Bob",
    			Sales = 1,
    			Keys = { "A", "B" }
    		},
    		new Employee{
    			Name = "Jane",
    			Sales = 2,
    			Keys = { "A", "C" }
    		}
    	};
    		
    	var grouping = (from e in employees
    			from k in employees.SelectMany(s => s.Keys).Distinct()
    			where e.Keys.Contains(k)						
    			select new 			
    			{
    				e.Name,
    				e.Sales,
    				Key = k			
    			})
    			.GroupBy(a => a.Key)
    			.Select(g => new { Key = g.Key, TotalSales = g.Select(a => a.Sales).Sum() });			
    }
    
    
    public class Employee
    {
    	public int Sales { get; set; }
    	public string Name { get; set; }
    	public List<string> Keys { get; set;}
    	
    	public Employee()
    	{
    		Keys = new List<string>();
    	}
    }
