    public class Range<T>
    {
    	public T Minimum { get; set; }
    	public T Maximum { get; set; }
    	public Func<T, T> Next { get; set; }
    	public Range(T min, T max) { Minimum = min; Maximum = max; }
    }
    
	public static IEnumerable<T> Expand<T>(this Range<T> range, Func<T, T> map) where T : IComparable<T>
	{
		T current = range.Minimum;
		while (current.CompareTo(range.Maximum) <= 0)
		{
			var result = map(current);
			yield return result;
			current = range.Next(current);
		}
	}
	Range<Int32> range = new Range<Int32>(20, 24);
	range.Next = x => x + 1;
	List<Int32> expect = new List<Int32> { 40, 21, 44, 23, 48 };
	List<Int32> result = range.Expand(x => x % 2 == 0 ? x * 2 : x).ToList();
    Assert.Equal(expect, result);
