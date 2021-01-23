	public
    static
    class IEnumerableExtensions
	{
		public
        static
        IEnumerable<int> CountConsecutiveElements<TElement>(this IEnumerable<TElement> ie,
                                                                 TElement consecutive_element)
			where TElement: IComparable<TElement>
		{
			using(var en = ie.GetEnumerator())
			{
				int i = 0;
				while (en.MoveNext())
				{
					if (en.Current.CompareTo(consecutive_element) == 0) i++;
					else if (i > 0)
					{
						yield return i;
						i = 0;
					}
				}
				if (i > 0) yield return i;
			}
		}
	}
