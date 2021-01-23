    using System;
    using AutoMapper;	
    					
    public class Program
    {
    	class SupplierInfo
    	{
    		public string Name {get; set; }
    		public string ShortName {get; set; }
    		public string BrandName {get; set; }
    	}
    	
    	class Supplier
    	{
    		public string name {get; set; }
    		public string shortName {get; set; }
    		public string brandName {get; set; }
    	}		
    	
    	public static void Main()
    	{
    		var dto = new Supplier() {
    			name = "Name 1",
    			shortName = "Short Name 1",
    			brandName = "Brand Name 1"
    		};
    		
    		
    		//From the tutorial:
    		//You only need one MapperConfiguration instance typically per AppDomain and should be instantiated during startup.
    		var config = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierInfo>());
    		
    		var mapper = config.CreateMapper();
    		
    		SupplierInfo info = mapper.Map<SupplierInfo>(dto);
    		
    		Console.WriteLine( info.Name );
    		Console.WriteLine( info.ShortName );
    		Console.WriteLine( info.BrandName );
    	}
    }
