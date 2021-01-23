    public static class LinqHelper
    {
    	public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int? k = null)
    	{
    		if (!k.HasValue)
    			k = elements.Count();
    
    		return k == 0 ? new[] { new T[0] } :
    		   elements.SelectMany((e, i) => elements.Skip(i).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
    	}
    }
	var list = new List<int> { 1, 3, 5, 7 };
    int x = 2; //Change to 3, 4, 5, etc
	var result = list.Combinations(x);
