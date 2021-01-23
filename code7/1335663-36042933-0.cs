    void Main()
    {
    	List<Company> postFilter = new List<UserQuery.Company>();
    
    	var sTerm = "XXX".Trim().ToUpper();
    	postFilter = postFilter.Where(x => 
    								 x.Facilities.Any(f => f.Name.ToUpper().Contains(sTerm)
    								                    || f.Description.ToUpper().Contains(sTerm))).ToList();
    }
    
    public class Company
    {
    	public string CompanyName { get; set; }
    	public List<Facility> Facilities { get; set; }
    		
    }
    
    public class Facility
    {
    	public string Name { get; set; }
    	public string Description { get; set; }
    }
