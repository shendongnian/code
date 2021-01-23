	public class SampleObjectComparer : IEqualityComparer<SampleObject>
	{
		public bool Equals(SampleObject a, SampleObject b)
		{
			return a.Id == b.Id 
				&& a.Events.SequenceEqual(b.Events);
		}
		public int GetHashCode(SampleObject a)
		{
			int hash = 17;
			
			hash = hash * 23 + a.Id.GetHashCode();
            foreach (var evt in a.Events)
            {
                hash = hash * 31 + evt.GetHashCode();
            }			
			
			return hash;
		}
	}
