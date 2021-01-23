     namespace Hosting
    {
        class Host //could be abstract also
    	{	
    		private string _hostAddress;
        	get { return "https://rest.connection.string/api"; }
    			
       
        }
    
    	public class CourseQueryInformation : Host
    	{
    		public CourseQueryInformation(string par, string par2)
    			{
    				...
    			}
    	}
       
    
        public class PersonQueryInformation : Host
    	{
    		public CourseQueryInformation(string par, string par2)
    		{
    			...
    		}
    	}
    
    }
