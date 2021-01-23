    public interface ICyclic<T> : IComparable<T>
    {
        ISet<T> Worse { get; set; }
        ISet<T> Better { get; set; }
    }
	public static ISet<IList<T>> Cycles<T>(this ISet<T> input) where T : ICyclic<T>
	{
		input = input.ToHashSet();
		Prepare(input);
		var output = new HashSet<IList<T>>(new CircleEqualityComparer<T>());
		foreach (var item in input)
		{
			bool detected;
			Visit(item, new List<T> { item }, item.Worse, output, out detected);
		}
		return output;
	}
	static void Prepare<T>(ISet<T> input) where T : ICyclic<T>
	{
		foreach (var item in input)
		{
			item.Worse = input.Where(t => t.CompareTo(item) < 0).ToHashSet();
			item.Better = input.Where(t => t.CompareTo(item) > 0).ToHashSet();
		}
		Action<Func<T, ISet<T>>> exceptionsRemover = x =>
		{
			var exceptions = new HashSet<T>();
			foreach (var item in input.OrderBy(t => x(t).Count))
			{
				x(item).ExceptWith(exceptions);
				if (!x(item).Any())
					exceptions.Add(item);
			}
			input.ExceptWith(exceptions);
		};
		exceptionsRemover(t => t.Worse);
		exceptionsRemover(t => t.Better);
	}
	static void Visit<T>(T item, List<T> visited, ISet<T> worse, ISet<IList<T>> output, 
                         out bool detected) where T : ICyclic<T>
	{
		detected = false;
		foreach (var bad in worse)
		{
			Func<T, T, bool> comparer = (t1, t2) => t1.CompareTo(t2) > 0;
			if (comparer(visited.Last(), visited.First()))
			{
				detected = true;
				var cycle = visited.ToList();
				output.Add(cycle);
			}
			if (visited.Contains(bad))
			{
				var cycle = visited.SkipWhile(x => !x.Equals(bad)).ToList();
				if (cycle.Count >= 3)
				{
					detected = true;
					output.Add(cycle);
				}
				continue;
			}
			if (bad.Equals(item) || comparer(bad, visited.Last()))
				continue;
			visited.Add(bad);
			Visit(item, visited, bad.Worse, output, out detected);
			if (detected)
				visited.Remove(bad);
		}
	}
	
	public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
	{
		return new HashSet<T>(source);
	}
    public class CircleEqualityComparer<T> : IEqualityComparer<ICollection<T>>
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
