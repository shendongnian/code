	public static TResult ConditionalAccess<TItem, TResult>(this TItem item, Func<TItem, TResult> accessor) where TResult : Class
	{
		if (item == null)
		{
			return null;
		}
		else
		{
			return accessor(item);
		}
	}
