		public class MyLineCompare : IEqualityComparer<string>
		{
			public bool Equals(string x, string y)
			{
				return (x == null && y == null)
                    || (x ?? "").Equals(y, StringComparison.OrdinalIgnoreCase);
			}
			
			public int GetHashCode(string x)
			{
				return x.GetHashCode();
			}
		}
