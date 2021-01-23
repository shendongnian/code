    public static IEnumerable<FieldInfo> DoMagic<T>(params Expression<Func<T, object>>[] include)
	{
		foreach(Expression<Func<T, object>> tree in include)
		{
			FieldInfo fi = null;
			// tree parser, which gets field info
			yield return fi;
		}
	}
