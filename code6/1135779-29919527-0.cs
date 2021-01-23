	void Main()
	{
			var vs = Enumerable.Range(0, 50).Select(i => Create(i));
			
			var groups = vs.GroupByKeys(new [] { "Scale" });
			
			Console.WriteLine("{0} groups", groups.Count());
			
			Console.WriteLine(string.Join(", ", groups.Select(g => g.Key)));
	}
	Employee Create(int i) {
		return new Employee { Scale = (((int)(i / 10)) * 10), DOB = new DateTime(2011, 11, 11), Sales = 50000 };
	
	}
	public class Employee
	{
		public string Designation {get ;set;}
		public string Discipline {get ;set;}
		public int Scale {get ;set;}
		public DateTime DOB {get ;set;}
		public int Sales {get ;set;}
	}
	
	public static class GroupByExtensions 
	{
		public static IEnumerable<IGrouping<string, TValue>> GroupByKeys<TValue>(this IEnumerable<TValue> values, IEnumerable<string> keys) 
		{
			var getters = typeof(TValue).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty)
				.Where(pi => keys.Contains(pi.Name))
				.Select(pi => pi.GetMethod)
				.Where(mi => mi != null)
				.ToArray();
			
			if (keys.Count() != getters.Length) 
			{
				throw new InvalidOperationException("Couldn't find all keys for grouping");
			}
			
			return values.GroupBy(v => getters.Aggregate("", (acc, getter) => string.Format("{0}¬{1}", acc, getter.Invoke(v, null).ToString())));
		
		}
	
	}
