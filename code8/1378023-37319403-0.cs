	private static bool IsValueTypeOrString(Type type)
	{
		return type.IsSubclassOf(typeof (ValueType)) || type == typeof(string);
    }
	public static void ShallowCopyEntity<T>(T source, T dest, params string[] except)
	{
		var props = typeof(T).GetProperties(BindingFlags.FlattenHierarchy|BindingFlags.Instance|BindingFlags.Public);
		foreach (var prop in props.Where(x => !except.Contains(x.Name) && IsValueTypeOrString(x.PropertyType)))
		{				
			var getMethod = prop.GetGetMethod(false);
			if(getMethod == null) continue;
			var setMethod = prop.GetSetMethod(false);
			if (setMethod == null) continue;
			prop.SetValue(dest, prop.GetValue(source));
		}
	}
