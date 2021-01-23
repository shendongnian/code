	public class TEqualityComparer : IEqualityComparer<T>
	{
		public bool Equals(T t1, T t2)
		{
			if (t2 == null && t1 == null)
				return true;
			else if (t1 == null || t2 == null)
				return false;
			else
			{
				return
					t1.X.Select(x => x.A).SequenceEqual(t2.X.Select(x => x.A))
					&& t1.X.Select(x => x.B).SequenceEqual(t2.X.Select(x => x.B));
			}
		}
	
		public int GetHashCode(T t)
		{
			return t.X.Select(x => x.A.GetHashCode())
				.Concat(t.X.Select(x => x.B.GetHashCode()))
				.Aggregate((x1, x2) => (x1 * 17 + 13) ^ x2);
		}
	}
