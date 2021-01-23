	public class SomeClass
	{
		public bool Field1 { get; set; }
		public bool Field2 { get; set; }	
		public bool Field3 { get; set; }	
		public bool Field4 { get; set; }
		
		public void SetAllFields(bool theValue)
		{
			Field1 = theValue;
			Field2 = theValue;
			Field3 = theValue;
			Field4 = theValue;
		}
	}
