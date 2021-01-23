    using System;
    	
    	public sealed class UserBusiness
    	{
    		
    		private static volatile UserBusiness instance;
    		private static readonly object syncRoot = new Object();
    
    		private UserBusiness() { }
    
    		public static UserBusiness Instance
    		{
    			get
    			{
    				if (instance == null)
    				{
    					lock (syncRoot)
    					{
    						if (instance == null)
    							instance = new UserBusiness();
    					}
    				}
    
    				return instance;
    			}
    		}
    
    		public void AddUser(User userToAdd)
    		{
    			//TODO use your ORM or whatever to acces database and add the user 
    			//for example if you use entityFramework you will need to do
    			//Context.Customers.Add(user)
    			//Context.SaveChanges();
    			//Just For Example
    		}
    	}
