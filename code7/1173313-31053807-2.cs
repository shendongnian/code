	public static IEnumerable<T> RemoveAllUntil<T>(
        this IEnumerable<T> input, 
        Predicate<T> match, 
        Predicate<T> until)
	{
		bool untilFound = false;
		
		foreach (T element in input)
		{
			if(!untilFound) untilFound = until(element);
			
			if(untilFound || !match(element))
			{
				yield return element;
			}
		}
	}
