    public class MyObjectDtoMapper 
    {
    	public MyObjectDtoMapper()
    	{
    		// configure AutoMapper here
    	}
    	
    	public MyObjectDto Map(MyObjectDao daoObject)
    	{
    	   var dtoObject = // map from daoObject with AutoMapper
    	   return dtoObject;
    	}
    	
    	public IEnumerable<MyObjectDto> Map(IEnumerable<MyObjectDao> daoObjects)
    	{
    	   return daoObjects.Select(Map);
    	}
    }
