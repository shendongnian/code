	public class ByNamePersonComparer : IEqualityComparer<Person>
	{
		public bool Equals(Person x, Person y)
		{
			return x.Name.Equals(y.Name, StringComparison.OrdinalIgnoreCase);
		}
	
		public int GetHashCode(Person obj)
		{
			return obj.GetHashCode();
		}
	}
		
		
