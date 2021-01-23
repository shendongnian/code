    public interface ICustomAttribute
    {
    	IEnumerable<PropertyAttribute> GetCustomAttributes(true);
    }
    
    class Person:ICustomAttribute
    {
    	IEnumerable<PropertyAttribute> GetCustomAttributes(true)
    	{
    	     //Validation logic here for Person entity.
             //Encapsulate your entity level logic here.
              return propertyInfo.GetCustomAttributes(true);
    	}
    }
        
    class Check:ICustomAttribute
    {
    	IEnumerable<PropertyAttribute> GetCustomAttributes(true)
    	{
    	     //Validation logic here for CHECK entity
             //Encapsulate your entity level logic here.
              return propertyInfo.GetCustomAttributes(true);
    	}
    }
        
    public ICustomAttribute GetInstanceForSubscriber(ValidationSubscribers validationSubscriber)
    {
    	//Use dependency injection to eliminate this if possible
    	switch (validationSubscriber)
    	{
    		case ValidationSubscribers.Person:
    			return new Person();
    		case ValidationSubscribers.Checks:
    			return new Checks();
    		default:
    			return null;
    	}
    }
