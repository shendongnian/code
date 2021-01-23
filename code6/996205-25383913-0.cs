	class Program
	{
		static void Main(string[] args)
		{
			DemoClass demo = new DemoClass { IntValue = 1, StringValue = "asdf" };
			var watcher = new DemoClassWatcher();
			watcher.Capture(demo);
			demo.StringValue = "1234";
			var results = watcher.Compare(demo); // results = "StringValue"
			demo.IntValue = 1234;
			results = watcher.Compare(demo); // results = "StringValue", "IntValue"
			watcher.Capture(demo);
			results = watcher.Compare(demo); // results = empty
		}
	}
	public class DemoClass
	{
		public string StringValue { get; set; }
		public int IntValue { get; set; }
	}
	public class DemoClassWatcher
	{
		private DemoClass lastRecorded = null;
		public void Capture(DemoClass objectToWatch)
		{
			lastRecorded = new DemoClass()
			{
				IntValue = objectToWatch.IntValue,
				StringValue = objectToWatch.StringValue
			};
		}
		public List<string> Compare(DemoClass currentObject)
		{
			var changes = new List<string>();
			var props = typeof(DemoClass).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (var propertyInfo in props)
			{
				var currentVal = propertyInfo.GetValue(currentObject);
				var prevVal = propertyInfo.GetValue(lastRecorded);
				if (currentVal is IComparable)
				{
					if ((currentVal as IComparable).CompareTo(prevVal) != 0)
						changes.Add(propertyInfo.Name);
					continue;
				}
				throw new NotSupportedException("Properties must support IComparable until someone fixes me up");
			}
			return changes;
		} 
	}
