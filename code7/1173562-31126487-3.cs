	public static IEnumerable<ICollection<T>> Cycles<T>(this ISet<T> input) where T : IComparable<T>
	{
		Func<T, T, bool> comparer = (t1, t2) => t1.CompareTo(t2) > 0;
		return Enumerable.Range(3, input.Count - 2)
			  .Select(x => input.Permutations(x))
			  .SelectMany(x => x)
			  .Select(x => x.ToList())
			  .Where(l => l.Zip(l.Skip(1), (t1, t2) => new { t1, t2 }).All(x => comparer(x.t1, x.t2))
					   && comparer(l.Last(), l.First()))
			  .Distinct(new CircleEqualityComparer<T>());
	}
	public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> list, int length)
	{
		if (length == 1)
			return list.Select(t => new[] { t });
		return Permutations(list, length - 1)
			  .SelectMany(t => list.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new[] { t2 }));
	}
    class CircleEqualityComparer<T> : IEqualityComparer<ICollection<T>>
    {
        public bool Equals(ICollection<T> x, ICollection<T> y)
        {
            if (x.Count != y.Count)
                return false;
            return Enumerable.Range(1, x.Count)
                  .Any(i => x.SequenceEqual(y.Skip(i).Concat(y.Take(i))));
        }
        public int GetHashCode(ICollection<T> obj)
        {
            return unchecked(obj.Aggregate(0, (x, y) => x + y.GetHashCode()));
        }
    }
