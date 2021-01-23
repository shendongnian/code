    public static IEnumerable<IEnumerable<T>> DifferentCombinations2<T>
        (this IEnumerable<T> elements, int k)
    {
     	return k == 0 
       		? EnumerableEx.Return(Enumerable.Empty<T>()) 
       		: elements.SelectMany((e, i) => 
       			elements.Skip(i + 1)
       				.DifferentCombinations2(k - 1)
       				.Select(c => EnumerableEx.Return(e).Concat(c)));
    }
