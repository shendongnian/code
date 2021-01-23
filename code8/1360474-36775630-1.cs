    public class Users
    	{
    	  public string Username {get;set;}
    	  public string Userid {get;set;}
    	}
    	
    void Main()
    {
    	var users = new List<Users>{new Users {Username="johndoe",Userid="123"},
    	                            new Users {Username="stevejobs",Userid="456"}
    								};
    	
    	var filter = users.Where(a => (a.Username.Equals("123") || a.Userid.Equals("123"))).ToList();
    	filter.Dump();
    	var filter2 = users.Where(a => (a.Username.Equals("456") || a.Userid.Equals("456"))).ToList();
    	filter2.Dump();
    }
