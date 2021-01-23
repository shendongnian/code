	// single string size :  18 bytes (empty string size) + 2 bytes per char allocated  
	//1 class instance ram cost : 4 * (18 + 2* charCount ) 
	// ie charcounts are at least 5
	//   cost: 4*(18+2*5)  = 110 byte 
	class MyObject 
	{
	    string Country ;
	    string Province ;
	    string City ;
	    string Street ;
	}
	public static class Exts
	{
		public static int AddDistinct_and_GetIndex(this List<string> list ,string value)
		{
			if( !list.Contains(value)  ) {
	        	list.Add(value);
	       	}
	     	return list.IndexOf(value);
		}
	}
	// 1 class instance ram cost : 4*4 byte = 16 byte
	class MyObjectOptimized
	{
        //those int's could be int16 depends on your distinct item counts
	    int Country_index ;
	    int Province_index ;
	    int City_index ;
	    int Street_index ;
	    // manuallly implemented properties  will not increase memory size
	    // whereas field WILL increase 
	    public string Country{ 
	    	get {return Country_li[Country_index]; }
	    	set {  Country_index = Country_li.AddDistinct_and_GetIndex(value); }
	    }
		public string Province{ 
	    	get {return Province_li[Province_index]; }
	    	set {  Province_index = Province_li.AddDistinct_and_GetIndex(value); }
	    }
	    public string City{ 
	    	get {return City_li[City_index]; }
	    	set {  City_index = City_li.AddDistinct_and_GetIndex(value); }
	    }
	    public string Street{ 
	    	get {return Street_li[Street_index]; }
	    	set {  Street_index = Street_li.AddDistinct_and_GetIndex(value); }
	    }
	    
	    //beware they are static.   
		static List<string> Country_li ;
		static List<string> Province_li ;
		static List<string> City_li ;
		static List<string> Street_li ;
	}
