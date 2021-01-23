    public void TestMethodAddUser() 
    {
    	int[] resul = new int[1];
    	resul[0] = 1;
    
    	Console.WriteLine(resul[0].ToString());
    
    	try 
    	{
    		if (resul[0] > 0) 
    		{
    			switch (resul[0]) 
    			{
    				case 1:
    					Console.WriteLine("Username taken.");
    					break;
    
    				case 2:
    					Console.WriteLine("Email address taken.");
    					break;
    			}
    
    			Console.WriteLine("User added.");
    		}
    
    	}
    	catch (Exception ex) 
    	{
    
    	}
    }
