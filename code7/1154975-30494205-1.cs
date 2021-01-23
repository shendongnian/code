    void Main()
	{
		List<MyClass> myColl = new List<MyClass>() { new MyClass() { myFirstProp = "1", mySecondProp = "ABC" } };
					
		foreach (MyClass r in myColl)
		{
			List<string> rPropsAsStrings = new List<string>();
			
			foreach (PropertyInfo propertyInfo in r.GetType().GetProperties())
			{
				rPropsAsStrings.Add(String.Format("{0} = {1}", propertyInfo.Name, propertyInfo.GetValue(r, null)));
			}
			
			Console.WriteLine(String.Join(", ", rPropsAsStrings.ToArray()));
		}
		
		
	}
	public class MyClass
	{
		public string myFirstProp { get; set; }
		public string mySecondProp { get; set; }
	}
