    public static class UserFactory
    {
    	public static User CreateActiveJuniorDeveloper(string firstName, string lastName, string userName)
    	{
    		 var newUser = new User
    			{
    				userBase =
    				{
    					FirstName = firstName,
    					LastName = lasteName,
    					Description = "Junior Developer",
    					IsActive = true,
    					State = ObjectState.Added,
    					RegistrationDate = DateTime.Now,
    					UserName = userName
    				}
    				
    				AssGroups = Enumerable.empty<IAdmGroup>();
    			};
    			
    		return newUser;
    	}
    }
    
    ...
    
    User developerUser = UserFactory.CreateActiveJuniorDeveloper("name1", "name2", "ASD");
