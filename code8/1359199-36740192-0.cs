    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class User {
    	public String Surname {get;set;}
    }
    
    static class Prog {
    	static void Main() {
    		List<User> AllUsers = new List<User>();
    		AllUsers.Add(new User(){Surname="jones"});
    		AllUsers.Add(new User(){Surname="meyer"});
    		AllUsers.Add(new User(){Surname="blackjones"});
    		AllUsers.Add(new User(){Surname="Jones"});
    		AllUsers.Add(new User(){Surname="Jonesmith"});
    		AllUsers.Add(new User(){Surname="ajonesee"});
    
    		List<User> FilteredUsers = new List<User>();
    		FilteredUsers.AddRange(AllUsers.Where(i => i.Surname.ToLower().Contains("jones")));
    		foreach (User u in FilteredUsers) {
    			Console.WriteLine(u.Surname);
    		}
    	}
    }
