	void Main()
	{
		var lstOuter= new List<A>();
	}
	
	// Define other methods and classes here
	class A
	{
		public A ()
		{
			ListB=new List<string>();
		}
		public string val{get; set;}
		public List<string> ListB { get; set; }
	}
	
	class B
	{
		public B ()
		{
			ListC=new List<string>();
		}
		public string val{get; set;}
		public List<string> ListC { get; set; }
	}
	
	
	class C
	{
		public C ()
		{
			ListD=new List<string>();
		}
		public string val{get; set;}
		public List<string> ListD { get; set; }
	
	}
