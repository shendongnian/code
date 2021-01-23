	void Main()
	{
		var obj = new TestClass<string>(i => string.Format("Element {0}", i));
		
		var sampleDateTimes = new HashSet<DateTime>();
		for(int i = 0; i < 4000 / 20; i++)
		{
			sampleDateTimes.Add(DateTime.Today.AddDays(i * -5));
		}
		var result = obj.GetItemsList_3(sampleDateTimes);
		foreach (var item in result)
		{
			Console.WriteLine(item);
		}
	}
	class TestClass<SomeObject>
	{
		private Dictionary<DateTime, SomeObject> _containedObjects;
		
		public TestClass(Func<int, SomeObject> converter)
		{
			_containedObjects = new Dictionary<DateTime, SomeObject>();
			for(int i = 0; i < 4000; i++)
			{
				_containedObjects.Add(DateTime.Today.AddDays(-i), converter(i));
			}
		}
		
		public IEnumerable<SomeObject> GetItemsList_1(HashSet<DateTime> requiredTimestamps)
		{
			List<SomeObject> toReturn = new List<SomeObject>();
			foreach(DateTime dateTime in requiredTimestamps)
			{
				SomeObject found;
				if(_containedObjects.TryGetValue(dateTime, out found))
				{
					toReturn.Add(found);
				}
			}
			return toReturn;
		}
		
		public IEnumerable<SomeObject> GetItemsList_2(HashSet<DateTime> requiredTimestamps)
		{
			foreach(DateTime dateTime in requiredTimestamps)
			{
				SomeObject found;
				if(_containedObjects.TryGetValue(dateTime, out found))
				{
					yield return found;
				}
			}
		}    
		
		public IEnumerable<SomeObject> GetItemsList_3(HashSet<DateTime> requiredTimestamps)
		{
			return requiredTimestamps
				.Intersect(_containedObjects.Keys)
				.Select (k => _containedObjects[k]);
		}
		
		public IEnumerable<SomeObject> GetItemsList_4(HashSet<DateTime> requiredTimestamps)
		{
			return requiredTimestamps
				.Where(dt => _containedObjects.ContainsKey(dt))
				.Select (dt => _containedObjects[dt]);
		}
	}
