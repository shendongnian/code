    public class User
    {
	public string FirstName { get; set; }
	public string LastName { get; set;}
    }
	void Main()
	{
		List<User> users = new List<User> { 
                               new User { FirstName = "john", LastName = "smith" }, 
                               new User { FirstName = "siler", LastName = "johnston" } };
		string searchName = "ja smi";
	 	String[] terms = searchName.Split(' ');	
		var items = users.Where(x => terms.Any(y => x.FirstName.Contains(y)) 
                                  || terms.Any(y => x.LastName.Contains(y)));
	}
 
