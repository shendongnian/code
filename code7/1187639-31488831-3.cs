    public class User 
    {
    	public int ID { get; set; }
    	public string Email { get; set; }
    
    	public override bool Equals(Object obj)
    	{
    		// Check for null values and compare run-time types.
    		if (obj == null || GetType() != obj.GetType())
    			return false;
    
    		User x = (User)obj;
    		return (ID == x.ID) && (Email == x.Email);
    	}
    
    	public override int GetHashCode()
    	{
    		return new { ID, Email }.GetHashCode();
    	}
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    
    		var usersL = new List<User>()
    			{
    				new User{ID = 1,Email = "abc@foo.com"},
    				new User{ID = 2,Email = "def@foo.com"}
    			};
    
    		var usersR = new List<User>()
    			{
    				new User{ID = 1,Email = "abc@foo.com"},
    				new User{ID = 2,Email = "def@foo.com"}
    			};
    
    		var both = (from l in usersL select l)
    		  .Intersect(from users in usersR select users);
    
    		foreach (var r in both)
    			Console.WriteLine(r.Email);
    	}
    }
