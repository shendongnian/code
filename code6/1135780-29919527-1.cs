	void Main()
	{
			var vs = Enumerable.Range(0, 50).Select(i => Create(i));
			
			var groups = vs.GroupByKeys(new Func<Employee, object>[] { x=> x.Scale });
			
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
		public static IEnumerable<IGrouping<string, TValue>> GroupByKeys<TValue>(this IEnumerable<TValue> values, IEnumerable<Func<TValue, object>> getters) 
		{
			
			return values.GroupBy(v => getters.Aggregate("", (acc, getter) => string.Format("{0}¬{1}", acc, getter(v).ToString())));
		
		}
	
	}
