	static class DataRowHelper<T>
	{
		public static int ToInt(this T item)
		{
			return Convert.ToInt32((object)(item == null ? 0 : (object)item));
		}
	}
