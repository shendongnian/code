	public List<List<decimal>> Solve(decimal transactionAmount, decimal[] elements)
	{
		// ....
		for (int j = 0; j < combinations; j++)
		{
		    // ....
			//Perfect result
			if (sum == transactionAmount)
				results.Add(new List<decimal>(result.OrderBy(t => t)));
		}
		results.Add(new List<decimal>(result.OrderBy(t => t)));
		return results.Distinct(new ListDecimalEquality()).ToList();
	}
	public class ListDecimalEquality : IEqualityComparer<List<decimal>>
	{
		public bool Equals(List<decimal> x, List<decimal> y)
		{
			return x.SequenceEqual(y);
		}
		public int GetHashCode(List<decimal> obj)
		{
			int hashCode = 0;
			for (int index = 0; index < obj.Count; index++)
			{
				hashCode ^= new { Index = index, Item = obj[index] }.GetHashCode();
			}
			return hashCode;
		}
	}
