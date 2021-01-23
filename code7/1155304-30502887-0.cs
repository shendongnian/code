	class MyClass
	{
		public void DoSomething()
		{
			List<string> myList = new List<string>()
			myList.Add("First Value");
			myList.AddMoreValues();
		}        
    }
    
    public static class ExtensionMethods
		private static void AddMoreValues(this List<string> theList)
		{
			theList.Add("1");
			theList.Add("2");
			...
		}
	}
