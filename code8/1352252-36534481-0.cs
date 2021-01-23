        public enum RepositoryTypes
        {
          SQL = 0,
          XML = 1
        }
        public static class RepositoryFactory
        {
    	  public static IRepositoryComputers GetComputers(RepositoryTypes repositoryType)
    	  {
    		  if (repositoryType.Equals(RepositoryTypes.SQL))
    		  	return new RepositoryComputersSQL();
    
    		  return new RepositoryComputersXML();            
    	  }
    
    	  public static IRepositoryUsers GetUsers(RepositoryTypes repositoryType)
    	  {
    		  if (repositoryType.Equals(RepositoryTypes.SQL))
    			  return new RepositoryUsersSQL();
    				
    		  return new RepositoryUsersXML();
    	  }
        }
