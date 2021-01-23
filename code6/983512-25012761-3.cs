    public class Util
    {
        public void Function(String s, Action<Status> statusChangeListener)
        {
            // ....
        }
    }
    
    public class Activity
    {
        public void AnotherFunction()
        {
            utilObj.Function("name", 
    		    (status) => 
    		    {
    				loginSetAvailabilityStatus(status);
    			}
        }       
    }
