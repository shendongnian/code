	public static IEnumerable<T> RemoveAllUntil<T>(
        this IEnumerable<T> input, 
        Func<T, bool> match, 
        Func<T, bool> until)
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
