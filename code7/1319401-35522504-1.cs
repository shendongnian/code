    using System;
    using AutoMapper;	
    					
    public class Program
    {
		class SupplierInfo
		{
			public SupplierInfo( string name, string shortName, string brandName ) {
				Name = name; 
				ShortName = shortName; 
				BrandName = brandName;
			}
			public string Name {get; private set; }
			public string ShortName {get; private set; }
			public string BrandName {get; private set; }
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
