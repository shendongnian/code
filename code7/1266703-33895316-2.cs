     namespace Hosting
    {
        class Host //could be abstract also
    	{	
    		private string _hostAddress = "foo";
        	get { return _hostAddress; }
    			
       
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
    		public PersonQueryInformation(string par, string par2)
    		{
    			...
    		}
    	}
    
    }
