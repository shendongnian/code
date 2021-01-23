        public class Duck
        {
    	    IDataAccess DataAccess { get; set; }
    	    IConverter Converter { get; set; }
    	    IConfigAccess ConfigAccess { get; set; }
    	    ITimezoneAccess TimezoneAccess { get; set; }
    	
    	    public Duck()
    	    {
                 // parameterless contructor 
    	    }
        }
