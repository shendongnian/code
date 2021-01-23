    public class Settings{
    
    	private dbUserDetails userDetails;
    
    	public string Bio {
    		return userDetails.Bio;
    	}
    
    	public Settings(dbUserDetails user, SomeOtherInfo other)
    	{
    		userDetails = user;
    		/*...*/
    	}
    }
