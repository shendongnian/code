    public class User
    {
    	public int ID { get; set; }
    	public string Email { get; set; }
    }
    
    public class MyEqualityComparer : IEqualityComparer<User>
    {
    	public bool Equals(User x, User y)
    	{
    		if (object.ReferenceEquals(x, y))
    			return true;
    		if (x == null || y == null)
    			return false;
    		return x.ID.Equals(y.ID) &&
    			   x.Email.Equals(y.Email);
    	}
    
    	public int GetHashCode(User u)
    	{
    		return new { u.ID, u.Email }.GetHashCode();
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
    
    		var both =  (from l in usersL select l)
    		  .Intersect(from users in usersR select users, new MyEqualityComparer());
    
    		foreach (var r in both)
    			Console.WriteLine(r.Email);
    	}
    }
