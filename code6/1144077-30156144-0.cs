	class SomeData
	{
		private string _string;
		private int _int; 
		
		public SomeData() : this("Default", 42)
		{
			
		}
	
		public SomeData(string str) : this(str, 42)
		{
	
		}
		
		public SomeData(string str, int num)
		{
			_int = num;
			_string = str; 
		}
	}
