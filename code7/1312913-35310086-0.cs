	public T GetVariable<T>(string key, T def)
	{
		var variables = SequenceContext.Current.Variables;
		if (variables.ContainsKey(key))
			return (T)Convert.ChangeType(variables[key], typeof(T));
		return def;
	}
	protected T GetVariable<T>(string key, Func<T> def)
	{
		return SequenceContext.Current.GetVariable<T>(key, def);
	}
