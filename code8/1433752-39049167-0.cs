    public static IMyInterface<T> Create<T>() where T : A 
	{
		if (typeof(B).IsAssignableFrom(typeof(T)))
		{
			var type = typeof(FirstImpl<>);
			var boundType = type.MakeGenericType(typeof(T));
			return (IMyInterface<T>) Activator.CreateInstance(boundType);
		}
		else if(typeof(C).IsAssignableFrom(typeof(T)))
		{
			var type = typeof(SecondImpl<>);
			var boundType = type.MakeGenericType(typeof(T));
			return (IMyInterface<T>) Activator.CreateInstance(boundType);
		}
		
		throw new ArgumentException("unknown type " + typeof(T).Name);
	}
