    public static class Extensions
    {
        public static T MaxValue<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
        	T maxValue = default(T);
        	foreach (var element in collection)
        	{
        		var comparsion = element.CompareTo(maxValue);
        		if (comparsion > 0)
        			maxValue = element;
        	}
        	return maxValue;
        }
        public static T MaxValue<T>(this IEnumerable<T> collection, IComparer<T> comparer)
        {
           T maxValue = default(T);
           foreach (var element in collection)
           {
               var comparsion = comparer.Compare(element, maxValue);
               if (comparsion > 0)
                   maxValue = element;
           }
           return maxValue;
        }
    }
