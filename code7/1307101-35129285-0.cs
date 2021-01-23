	public class SampleObjectComparer : IEqualityComparer<SampleObject>
	{
		public bool Equals(SampleObject x, SampleObject y)
		{
			return x.Id == y.Id && x.Events.SequenceEqual(y.Events);
		}
		
		public int GetHashCode(SampleObject x)
		{
			return x.Id.GetHashCode() ^ x.Events.Aggregate(0, (a, y) => a ^ y.GetHashCode());
		}
	}
