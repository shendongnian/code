	public static class PrivateExtensions
	{
		public static void ClearForUnitTest<T>(this T instance)
		{
			var method = typeof(T).GetMethod("ClearForUnitTest", BindingFlags.NonPublic | BindingFlags.Instance);
			method.Invoke(instance, null);
		}
	}
