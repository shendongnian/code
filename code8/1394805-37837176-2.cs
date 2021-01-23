    public static IEnumerable<T> ThrowIfConsecutiveItemsAreEqual<T>(this IEnumerable<T> source)
	{
	    bool isFirst = true;
		T prev = default(T);
	    foreach(var item in source)
		{
		    if(!isFirst && item.Equals(prev))
			    throw new Exception();  // TODO: use a better exception type and message
				
			yield return item;
			
			isFirst = false;
			prev = item;
		}
	}
