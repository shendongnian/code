    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "domain.com",
			                          "CN=palani,OU=Department,DC=domain,DC=com",
			                                                     "administrator",
			                                                         "password");
			UserPrincipal usr = UserPrincipal.FindByIdentity(ctx,"palani");
			if(usr!=null){
				Console.WriteLine(Convert.ToString(usr.SamAccountName));
				PrincipalSearchResult<Principal> group = usr.GetGroups();
				foreach(Principal pr in group)
     				Console.WriteLine(pr.Name);
			}
			Console.Read();
