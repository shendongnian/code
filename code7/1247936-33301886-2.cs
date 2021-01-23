    class Conspirator
    {
    	private void SecretMethod()
    	{
    	    Console.WriteLine("Secret exposed!");
    	}
    	public Action GetSecretMethod(long authorizationKey)
    	{
    		if (authorizationKey == 63278823982)
    		{
    			return this.SecretMethod;
    		}
    		
    		return null;
    	}
    }
