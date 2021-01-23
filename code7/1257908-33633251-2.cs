	public static class IsNullable<T>
	{
		private static readonly Type type = typeof(T);
		private static readonly bool is_nullable = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
		public static bool Result { get { return is_nullable; } }
	}
    
     public static class Extension
     {
         public static T CastColumnData<T>(this DataRow row,
                                           string columnName)
        {
			object obj;
			if (row == null) throw new ArgumentNullException("row is null");
			if ((obj = row[columnName]) == null) throw new ArgumentNullException("row[" + columnName + "]  is null");
			bool is_dbnull = obj == DBNull.Value;
			if (is_dbnull && !IsNullable<T>.Result) throw new InvalidCastException("Columns data are DbNull, but the T[" + typeof(T).ToString() + "] is non nullable value type");
			return is_dbnull ? default(T) : (T)obj;
         }
     }
