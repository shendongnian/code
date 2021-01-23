    using System;
    
    namespace test
    {
    	public class NameIdObject
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }
    	
    	public static class MyCache
        {
            public static NameIdObject MyCacheObject = new NameIdObject();
        }
    	
    	public static class Program
    	{
    		public static void Main()
    		{
    			MyCache.MyCacheObject.Name = "foo";
    			MyCache.MyCacheObject.Id = 123;
    			
    		}
    	}
    }
