	public static class Helper
	{
		static public T ToViewModel<T, K>(this K dbmlClass)
		{
			return (T)Activator.CreateInstance(typeof(T), dbmlClass);
		}
	}
