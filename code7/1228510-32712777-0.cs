     public class Properties
     {
    	 public IDictionary<string, string> ExtendedProperties
    	 {
    		 get;
    		 set;
    	 }
    	 
    	 public Properties(string [] fields)
    	 {
    		 ExtendedProperties = new Dictionary<string, string> ();
    		 foreach(var s in fields)
    		 {
    			 ExtendedProperties.Add(s,string.Empty);
    		 }
    	 }
     }
