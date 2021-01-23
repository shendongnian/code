	public IEnumerable<IEnumerable<T>> Permutate<T>(IEnumerable<T> source)
	{
		var xs = source.ToArray();
		return
			xs.Length == 1
				? new [] { xs }
				: (
					from n in Enumerable.Range(0, xs.Length)
					let cs = xs.Skip(n).Take(1)
					let dss = Permutate<T>(xs.Take(n).Concat(xs.Skip(n + 1)))
					from ds in dss
					select cs.Concat(ds)
				).Distinct(new EnumerableEqualityComparer<T>());
	}
	
	private class EnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
	{
		public bool Equals(IEnumerable<T> a, IEnumerable<T> b)
		{
			return a.SequenceEqual(b);
		}
		
		public int GetHashCode(IEnumerable<T> t)
		{
			return t.Take(1).Aggregate(0, (a, x) => a ^ x.GetHashCode());
		}
	}
