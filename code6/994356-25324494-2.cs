	MethodInfo write = ActionInfo(Console.WriteLine);
	MethodInfo empty = FuncInfo(string.IsNullOrEmpty);
	MethodInfo emptyT = FuncInfoT<string, bool>(string.IsNullOrEmpty);
	public static MethodInfo ActionInfo(Action act)
	{
		return act.Method;
	}
	public static MethodInfo FuncInfo(Func<string, bool> fn)
	{
		return fn.Method;
	}
	public static MethodInfo FuncInfoT<T1, T2>(Func<T1, T2> fn)
	{
		return fn.Method;
	}
