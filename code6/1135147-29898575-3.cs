	public static class ArrayFromList
	{
		public static FieldInfo GetField<T>()
		{
			return ArrayFromListImpl<T>.Field;
		}
		public static T[] GetArray<T>(List<T> list)
		{
			return ArrayFromListImpl<T>.GetArray(list);
		}
		public static class ArrayFromListImpl<T>
		{
			public static readonly FieldInfo Field;
			public static readonly Func<List<T>, T[]> GetArray;
			static ArrayFromListImpl()
			{
				Field = typeof(List<T>)
					.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
					.Where(x => x.FieldType == typeof(T[]))
					.Single();
				var par = Expression.Parameter(typeof(List<T>));
				var exp = Expression.Lambda<Func<List<T>, T[]>>(Expression.Field(par, Field), par);
				GetArray = exp.Compile();
			}
		}
	}
