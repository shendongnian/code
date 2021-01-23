    public class Range
    {
    	public int Minimum { get; set; }
    	public int Maximum { get; set; }
    	public Range(int min, int max) { Minimum = min; Maximum = max; }
    }
    
    public static IEnumerable<T> Expand<T>(Range range, Func<int, T> map)
    {
    	var start = range.Minimum;
    	var count = range.Maximum - range.Minimum + 1;
    	var sequence = Enumerable.Range(start, count).Select(x => map(x));
    	foreach (var item in sequence)
    		yield return item;
    }
    
    
    Range range = new Range(20, 24);
    List<Int32> expect = new List<Int32> { 40, 21, 44, 23, 48 };
    List<Int32> result = Expand(range, x => x % 2 == 0 ? x * 2 : x).ToList();
    Assert.Equal(expect, result);
