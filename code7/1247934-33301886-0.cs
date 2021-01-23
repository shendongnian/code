    class Conspirator
    {
    	public Action GetSecretMethod(long authorizationKey)
    	{
    		if (authorizationKey == 63278823982)
    		{
    			return this.SecretMethod;
    		}
    		
    		return null;
    	}
    
    	private void SecretMethod()
    	{
    	    Console.WriteLine("Secret exposed!");
    	}
    }
