	static void Main()
	{
		var expected = new List<long[]> { new[] { Convert.ToInt64(1), Convert.ToInt64(999999) } };
		var actual = DoSomething();
		
		if (!actual.SequenceEqual(expected, new LongArrayComparer()))
			throw new Exception();
	}
	public class LongArrayComparer : EqualityComparer<long[]>
	{
		public override bool Equals(long[] first, long[] second)
		{
			return first.SequenceEqual(second);
		}
	
		// GetHashCode implementation in the courtesy of @JonSkeet
		// from http://stackoverflow.com/questions/7244699/gethashcode-on-byte-array
		public override int GetHashCode(long[] arr)
		{
			unchecked
			{
				if (array == null)
				{
					return 0;
				}
				
				int hash = 17;
				foreach (long element in arr)
				{
					hash = hash * 31 + element.GetHashCode();
				}
				
				return hash;
			}
		}
	}
