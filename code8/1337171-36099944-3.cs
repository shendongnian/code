	public static class Helper
	{
		static public T ToViewModel<T>(this object dbmlClass)
		{
			return (T)Activator.CreateInstance(typeof(T), dbmlClass);
		}
	}
