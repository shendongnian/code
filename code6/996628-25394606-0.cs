	void GetDistinctValues(string aPropName)
	{
		var props = typeof(A).GetProperties();
		
		// make sure your property exists here, otherwise return
		
		// Something like that should be what you want:
		var return_col = gridItems[aPropName].Distinct();
	}
	
	public class A {
		public int Age{get;set;}
		public int Height{get;set;}
	}
