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
            public static NameIdObject MyCacheObject;
        }
    	
    	public static class Program
    	{
    		public static void Main()
    		{
                MyCache.MyCacheObject = new NameIdObject { Id = 123, Name = "foo" };
    		}
    	}
    }
