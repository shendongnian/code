	public class SomeClass
	{
		public bool Prop1 { get; set; }
		public bool Prop2 { get; set; }	
		public bool Prop3 { get; set; }	
		public bool Prop4 { get; set; }
		
		public void SetAllProps(bool theValue)
		{
			Prop1 = theValue;
			Prop2 = theValue;
			Prop3 = theValue;
			Prop4 = theValue;
		}
	}
