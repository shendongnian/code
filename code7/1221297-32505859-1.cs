    	public interface ILookups
    	{
    		List<Region> GetRegions(string language);
    		List<Industry> GetIndustries(string language);
    		List<Dimension> GetDimensions(string language);
    		List<SubjectType> GetSubjectTypes(string language);
    		
    		// maybe add this
            // this makes it clear to the consumer that it could receive an extended lookup
            // one class returns "this", the other "null" 
            IExtendedLookUps GetExtendedOrNull { get;}
    	}
    	 
   	    public interface IExtendedLookups : ILookups
    	{
    	    List<People> GetPeople();
    	}
    	 
    	 void consumerCode()
    	 {
    		ILookups lookups = factory.CreateLookups();
    		
    		// code that works for both cases
    		lookups.GetRegions("en");
    		
    		// do something special if it implements IExtendedLookups
    		if (lookups is IExtendedLookups)
    		{
    			var extendedLookups = lookups as IExtendedLookups;
    			extendedLookups.GetPeople();
    		}
            // or with the additional interface property:
            var maybeExtendedLookups = lookups.GetExtendedOrNull;
    		if (maybeExtendedLookups  != null)
    		{
                maybeExtendedLookups.GetPeople();
    		}
    
    	 }
